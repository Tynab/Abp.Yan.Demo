using Volo.Abp.Threading;

namespace Yan.Demo.EntityFrameworkCore;

public static class DemoEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public static void Configure()
    {
        DemoGlobalFeatureConfigurator.Configure();
        DemoModuleExtensionConfigurator.Configure();
        OneTimeRunner.Run(() => { });
    }
}
