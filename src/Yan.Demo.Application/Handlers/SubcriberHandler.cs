using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using Yan.Demo.Etos;
using Yan.Demo.Requests;
using YANLib;
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
        var dto = ObjectMapper.Map<MessageEto, MessageRequest>(eventData);
        _logger.LogInformation("SubcriberHandler: {ETO}", Serialize(dto));
        _logger.LogInformation("SubcriberHandler: {DTO}", Serialize(dto.ChangeTimeZoneAllProperties(0, 7)));
        return CompletedTask;
    }
    #endregion
}
