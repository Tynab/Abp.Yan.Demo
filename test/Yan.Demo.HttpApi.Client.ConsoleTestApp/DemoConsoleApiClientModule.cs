using Microsoft.Extensions.DependencyInjection;
using Polly;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;
using static System.Math;
using static System.TimeSpan;

namespace Yan.Demo.HttpApi.Client.ConsoleTestApp;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DemoHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class DemoConsoleApiClientModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context) => PreConfigure<AbpHttpClientBuilderOptions>(o => o.ProxyClientBuildActions.Add((remoteServiceName, clientBuilder) => clientBuilder.AddTransientHttpErrorPolicy(b => b.WaitAndRetryAsync(3, i => FromSeconds(Pow(2, i))))));
}
