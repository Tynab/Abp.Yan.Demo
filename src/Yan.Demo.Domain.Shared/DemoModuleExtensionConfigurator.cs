using Volo.Abp.Threading;

namespace Yan.Demo;

public static class DemoModuleExtensionConfigurator
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public static void Configure() => OneTimeRunner.Run(() =>
    {
        ConfigureExistingProperties();
        ConfigureExtraProperties();
    });

    private static void ConfigureExistingProperties() { }

    private static void ConfigureExtraProperties() { }
}
