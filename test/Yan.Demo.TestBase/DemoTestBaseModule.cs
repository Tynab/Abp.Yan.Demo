﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using static Volo.Abp.Threading.AsyncHelper;

namespace Yan.Demo;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpTestBaseModule),
    typeof(AbpAuthorizationModule),
    typeof(DemoDomainModule)
    )]
public class DemoTestBaseModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context) { }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(o => o.IsJobExecutionEnabled = false);
        _ = context.Services.AddAlwaysAllowAuthorization();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context) => SeedTestData(context);

    private static void SeedTestData(ApplicationInitializationContext context) => RunSync(async () =>
    {
        using var scope = context.ServiceProvider.CreateScope();
        await scope.ServiceProvider.GetRequiredService<IDataSeeder>().SeedAsync();
    });
}
