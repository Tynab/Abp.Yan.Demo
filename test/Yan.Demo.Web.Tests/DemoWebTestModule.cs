using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;
using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Validation.Localization;
using Yan.Demo.Localization;
using Yan.Demo.Web;
using Yan.Demo.Web.Menus;

namespace Yan.Demo;

[DependsOn(
    typeof(AbpAspNetCoreTestBaseModule),
    typeof(DemoWebModule),
    typeof(DemoApplicationTestModule)
)]
public class DemoWebTestModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context) => context.Services.PreConfigure<IMvcBuilder>(b => b.PartManager.ApplicationParts.Add(new CompiledRazorAssemblyPart(typeof(DemoWebModule).Assembly)));

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalizationServices(context.Services);
        ConfigureNavigationServices(context.Services);
    }

    private static void ConfigureLocalizationServices(IServiceCollection services)
    {
        var cultures = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("tr")
        };
        _ = services.Configure<RequestLocalizationOptions>(o =>
        {
            o.DefaultRequestCulture = new RequestCulture("en");
            o.SupportedCultures = cultures;
            o.SupportedUICultures = cultures;
        });
        _ = services.Configure<AbpLocalizationOptions>(o => o.Resources.Get<DemoResource>().AddBaseTypes(typeof(AbpValidationResource), typeof(AbpUiResource)));
    }

    private static void ConfigureNavigationServices(IServiceCollection services) => services.Configure<AbpNavigationOptions>(o => o.MenuContributors.Add(new DemoMenuContributor()));
}
