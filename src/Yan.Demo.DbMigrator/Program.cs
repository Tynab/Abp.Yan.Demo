using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;
using static Microsoft.Extensions.Hosting.Host;
using static Serilog.Events.LogEventLevel;

namespace Yan.Demo.DbMigrator;

class Program
{
    static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", Warning)
            .MinimumLevel.Override("Volo.Abp", Warning)
#if DEBUG
                .MinimumLevel.Override("Yan.Demo", Debug)
#else
                .MinimumLevel.Override("Yan.Demo", Information)
#endif
                .Enrich.FromLogContext()
            .WriteTo.Async(x => x.File("Logs/logs.txt"))
            .WriteTo.Async(x => x.Console())
            .CreateLogger();
        await CreateHostBuilder(args).RunConsoleAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => CreateDefaultBuilder(args).AddAppSettingsSecretsJson().ConfigureLogging((context, logging) => logging.ClearProviders()).ConfigureServices((hostContext, services) => services.AddHostedService<DbMigratorHostedService>());
}
