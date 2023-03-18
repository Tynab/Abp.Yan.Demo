using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using static System.Threading.Tasks.Task;

namespace Yan.Demo.HttpApi.Client.ConsoleTestApp;

public class ConsoleTestAppHostedService : IHostedService
{
    #region Fields
    private readonly IConfiguration _configuration;
    #endregion

    #region Constructors
    public ConsoleTestAppHostedService(IConfiguration configuration) => _configuration = configuration;
    #endregion

    #region Implements
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await AbpApplicationFactory.CreateAsync<DemoConsoleApiClientModule>(o =>
        {
            _ = o.Services.ReplaceConfiguration(_configuration);
            o.UseAutofac();
        });
        await application.InitializeAsync();
        await application.ServiceProvider.GetRequiredService<ClientDemoService>().RunAsync();
        await application.ShutdownAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken) => CompletedTask;
    #endregion
}
