using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using static Microsoft.Extensions.Hosting.Host;

namespace Yan.Demo.HttpApi.Client.ConsoleTestApp;

class Program
{
    static async Task Main(string[] args) => await CreateHostBuilder(args).RunConsoleAsync();

    public static IHostBuilder CreateHostBuilder(string[] args) => CreateDefaultBuilder(args).AddAppSettingsSecretsJson().ConfigureServices((hostContext, services) => services.AddHostedService<ConsoleTestAppHostedService>());
}
