using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using Yan.Demo.Etos;
using Yan.Demo.Requests;
using static System.Text.Json.JsonSerializer;
using static System.Threading.Tasks.Task;

namespace Yan.Demo.Handlers;

public class SubcriberHandler : DemoAppService, IDistributedEventHandler<MessageEto>
{
    #region Fields
    private readonly ILogger<SubcriberHandler> _logger;
    #endregion

    #region Constructors
    public SubcriberHandler(ILogger<SubcriberHandler> logger) => _logger = logger;
    #endregion

    #region Implements
    public Task HandleEventAsync(MessageEto eventData)
    {
        _logger.LogInformation("SubcriberHandler: {ETO}", Serialize(ObjectMapper.Map<MessageEto, MessageRequest>(eventData)));
        return CompletedTask;
    }
    #endregion
}
