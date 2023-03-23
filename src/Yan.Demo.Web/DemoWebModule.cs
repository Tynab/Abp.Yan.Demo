using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.EventBus.Kafka;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Http.Client;
using Volo.Abp.Identity.Web;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using Yan.Demo.EntityFrameworkCore;
using Yan.Demo.Localization;
using Yan.Demo.Web.Menus;
using static OpenIddict.Validation.AspNetCore.OpenIddictValidationAspNetCoreDefaults;
using static System.IO.Path;
using static Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling.LeptonXLiteThemeBundles.Styles;
using static Yan.Demo.MultiTenancy.MultiTenancyConsts;

namespace Yan.Demo.Web;

[DependsOn(
    typeof(DemoHttpApiModule),
    typeof(DemoApplicationModule),
    typeof(DemoEntityFrameworkCoreModule),
    typeof(AbpAutofacModule),
    typeof(AbpIdentityWebModule),
    typeof(AbpSettingManagementWebModule),
    typeof(AbpAccountWebOpenIddictModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(AbpTenantManagementWebModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpEventBusKafkaModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(AbpHttpClientModule)
    )]
public class DemoWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        _ = context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(o => o.AddAssemblyResource(
            typeof(DemoResource),
            typeof(DemoDomainModule).Assembly,
            typeof(DemoDomainSharedModule).Assembly,
            typeof(DemoApplicationModule).Assembly,
            typeof(DemoApplicationContractsModule).Assembly,
            typeof(DemoWebModule).Assembly
            ));
        PreConfigure<OpenIddictBuilder>(o => o.AddValidation(b =>
        {
            _ = b.AddAudiences("Demo");
            _ = b.UseLocalServer();
            _ = b.UseAspNetCore();
        }));
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;
        ConfigureAuthentication(context);
        ConfigureUrls(services.GetConfiguration());
        ConfigureBundles();
        ConfigureAutoMapper();
        ConfigureVirtualFileSystem(services.GetHostingEnvironment());
        ConfigureNavigationServices();
        ConfigureAutoApiControllers();
        ConfigureSwaggerServices(services);
    }

    private static void ConfigureAuthentication(ServiceConfigurationContext context) => context.Services.ForwardIdentityAuthenticationForBearer(AuthenticationScheme);

    private void ConfigureUrls(IConfiguration configuration) => Configure<AppUrlOptions>(o => o.Applications["MVC"].RootUrl = configuration["App:SelfUrl"]);

    private void ConfigureBundles() => Configure<AbpBundlingOptions>(o => o.StyleBundles.Configure(Global, c => c.AddFiles("/global-styles.css")));

    private void ConfigureAutoMapper() => Configure<AbpAutoMapperOptions>(o => o.AddMaps<DemoWebModule>());

    private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
    {
        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(o =>
            {
                var path = hostingEnvironment.ContentRootPath;
                var prefix = $"..{DirectorySeparatorChar}Yan.Demo.";
                o.FileSets.ReplaceEmbeddedByPhysical<DemoDomainSharedModule>(Combine(path, $"{prefix}Domain.Shared"));
                o.FileSets.ReplaceEmbeddedByPhysical<DemoDomainModule>(Combine(path, $"{prefix}Domain"));
                o.FileSets.ReplaceEmbeddedByPhysical<DemoApplicationContractsModule>(Combine(path, $"{prefix}Application.Contracts"));
                o.FileSets.ReplaceEmbeddedByPhysical<DemoApplicationModule>(Combine(path, $"{prefix}Application"));
                o.FileSets.ReplaceEmbeddedByPhysical<DemoWebModule>(path);
            });
        }
    }

    private void ConfigureNavigationServices() => Configure<AbpNavigationOptions>(o => o.MenuContributors.Add(new DemoMenuContributor()));

    private void ConfigureAutoApiControllers() => Configure<AbpAspNetCoreMvcOptions>(o => o.ConventionalControllers.Create(typeof(DemoApplicationModule).Assembly));

    private static void ConfigureSwaggerServices(IServiceCollection services) => services.AddAbpSwaggerGen(o =>
    {
        o.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Demo API",
            Version = "v1"
        });
        o.DocInclusionPredicate((docName, description) => true);
        o.CustomSchemaIds(t => t.FullName);
    });

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        if (env.IsDevelopment())
        {
            _ = app.UseDeveloperExceptionPage();
        }
        _ = app.UseAbpRequestLocalization();
        if (!env.IsDevelopment())
        {
            _ = app.UseErrorPage();
        }
        _ = app.UseCorrelationId();
        _ = app.UseStaticFiles();
        _ = app.UseRouting();
        _ = app.UseAuthentication();
        _ = app.UseAbpOpenIddictValidation();
        if (IsEnabled)
        {
            _ = app.UseMultiTenancy();
        }
        _ = app.UseUnitOfWork();
        _ = app.UseAuthorization();
        _ = app.UseSwagger();
        _ = app.UseAbpSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API"));
        _ = app.UseAuditing();
        _ = app.UseAbpSerilogEnrichers();
        _ = app.UseConfiguredEndpoints();
    }
}
