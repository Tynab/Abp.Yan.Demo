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
using Volo.Abp.EventBus.RabbitMq;
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
using Yan.Demo.Web.Extensions;
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
    typeof(AbpEventBusRabbitMqModule)
    )]
public class DemoWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options => options.AddAssemblyResource(
            typeof(DemoResource),
            typeof(DemoDomainModule).Assembly,
            typeof(DemoDomainSharedModule).Assembly,
            typeof(DemoApplicationModule).Assembly,
            typeof(DemoApplicationContractsModule).Assembly,
            typeof(DemoWebModule).Assembly
            ));

        PreConfigure<OpenIddictBuilder>(builder => builder.AddValidation(options =>
        {
            _ = options.AddAudiences("Demo");
            _ = options.UseLocalServer();
            _ = options.UseAspNetCore();
        }));
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        ConfigureAuthentication(context);
        ConfigureUrls(configuration);
        ConfigureBundles();
        ConfigureAutoMapper();
        ConfigureVirtualFileSystem(hostingEnvironment);
        ConfigureNavigationServices();
        ConfigureAutoApiControllers();
        ConfigureSwaggerServices(context.Services);
    }

    private static void ConfigureAuthentication(ServiceConfigurationContext context) => context.Services.ForwardIdentityAuthenticationForBearer(AuthenticationScheme);

    private void ConfigureUrls(IConfiguration configuration) => Configure<AppUrlOptions>(options => options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"]);

    private void ConfigureBundles() => Configure<AbpBundlingOptions>(options => options.StyleBundles.Configure(Global, bundle => bundle.AddFiles("/global-styles.css")));

    private void ConfigureAutoMapper() => Configure<AbpAutoMapperOptions>(options => options.AddMaps<DemoWebModule>());

    private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
    {
        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<DemoDomainSharedModule>(Combine(hostingEnvironment.ContentRootPath, $"..{DirectorySeparatorChar}Yan.Demo.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<DemoDomainModule>(Combine(hostingEnvironment.ContentRootPath, $"..{DirectorySeparatorChar}Yan.Demo.Domain"));
                options.FileSets.ReplaceEmbeddedByPhysical<DemoApplicationContractsModule>(Combine(hostingEnvironment.ContentRootPath, $"..{DirectorySeparatorChar}Yan.Demo.Application.Contracts"));
                options.FileSets.ReplaceEmbeddedByPhysical<DemoApplicationModule>(Combine(hostingEnvironment.ContentRootPath, $"..{DirectorySeparatorChar}Yan.Demo.Application"));
                options.FileSets.ReplaceEmbeddedByPhysical<DemoWebModule>(hostingEnvironment.ContentRootPath);
            });
        }
    }

    private void ConfigureNavigationServices() => Configure<AbpNavigationOptions>(options => options.MenuContributors.Add(new DemoMenuContributor()));

    private void ConfigureAutoApiControllers() => Configure<AbpAspNetCoreMvcOptions>(options => options.ConventionalControllers.Create(typeof(DemoApplicationModule).Assembly));

    private static void ConfigureSwaggerServices(IServiceCollection services) => services.AddAbpSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Demo API",
            Version = "v1"
        });
        options.DocInclusionPredicate((docName, description) => true);
        options.CustomSchemaIds(type => type.FullName);
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
        _ = app.UseAbpSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API"));
        _ = app.UseAuditing();
        _ = app.UseAbpSerilogEnrichers();
        _ = app.UseConfiguredEndpoints();
    }

    public override void Configure(IApplicationBuilder app)
    {
        app.UseDemoModuleExceptionHandler();
        base.Configure(app);
    }
}
