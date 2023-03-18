using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.OpenIddict;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using static Microsoft.Extensions.DependencyInjection.ServiceDescriptor;
using static Yan.Demo.MultiTenancy.MultiTenancyConsts;

namespace Yan.Demo;

[DependsOn(
    typeof(DemoDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpBackgroundJobsDomainModule),
    typeof(AbpFeatureManagementDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpOpenIddictDomainModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpTenantManagementDomainModule),
    typeof(AbpEmailingModule)
)]
public class DemoDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(o =>
        {
            o.Languages.Add(new LanguageInfo("ar", "ar", "العربية", "ae"));
            o.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            o.Languages.Add(new LanguageInfo("en", "en", "English", "gb"));
            o.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            o.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            o.Languages.Add(new LanguageInfo("fi", "fi", "Finnish", "fi"));
            o.Languages.Add(new LanguageInfo("fr", "fr", "Français", "fr"));
            o.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
            o.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
            o.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            o.Languages.Add(new LanguageInfo("ru", "ru", "Русский", "ru"));
            o.Languages.Add(new LanguageInfo("sk", "sk", "Slovak", "sk"));
            o.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe", "tr"));
            o.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            o.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            o.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
            o.Languages.Add(new LanguageInfo("es", "es", "Español"));
        });
        Configure<AbpMultiTenancyOptions>(o => o.IsEnabled = IsEnabled);
#if DEBUG
        context.Services.Replace(Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}
