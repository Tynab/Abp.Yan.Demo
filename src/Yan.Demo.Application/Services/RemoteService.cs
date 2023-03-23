using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.Http.Client;

namespace Yan.Demo.Services;

public class RemoteService : DemoAppService, IRemoteService
{
    private readonly ILogger<RemoteService> _logger;
    private readonly AbpRemoteServiceOptions _remoteServiceOptions;

    public RemoteService(ILogger<RemoteService> logger, IOptionsSnapshot<AbpRemoteServiceOptions> remoteServiceOptions)
    {
        _logger = logger;
        _remoteServiceOptions = remoteServiceOptions.Value;
    }

    public Task Test()
    {
        _remoteServiceOptions.RemoteServices.TryGetValue("Test", out var rmtSvcConfig);
        _logger.LogInformation("Url: {URL}", rmtSvcConfig.BaseUrl);
        return Task.CompletedTask;
    }
}
