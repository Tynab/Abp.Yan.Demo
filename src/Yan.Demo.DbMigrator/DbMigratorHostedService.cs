using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Yan.Demo.Data;
using static System.Threading.Tasks.Task;
using static Volo.Abp.AbpApplicationFactory;

namespace Yan.Demo.DbMigrator;

public class DbMigratorHostedService : IHostedService
{
    #region Fields
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConfiguration _configuration;
    #endregion

    #region Constructors
    public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _configuration = configuration;
    }
    #endregion

    #region Implements
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await CreateAsync<DemoDbMigratorModule>(o =>
        {
            _ = o.Services.ReplaceConfiguration(_configuration);
            o.UseAutofac();
            _ = o.Services.AddLogging(b => b.AddSerilog());
            o.AddDataMigrationEnvironment();
        });
        await application.InitializeAsync();
        await application.ServiceProvider.GetRequiredService<DemoDbMigrationService>().MigrateAsync();
        await application.ShutdownAsync();
        _hostApplicationLifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken) => CompletedTask;
    #endregion
}
