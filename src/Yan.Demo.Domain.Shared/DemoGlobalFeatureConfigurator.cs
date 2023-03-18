using Volo.Abp.Threading;

namespace Yan.Demo;

public static class DemoGlobalFeatureConfigurator
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public static void Configure() => OneTimeRunner.Run(() => { });
}
