using Volo.Abp.Threading;

namespace Yan.Demo;

public static class DemoDtoExtensions
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public static void Configure() => OneTimeRunner.Run(() => { });
}
