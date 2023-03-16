using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using Yan.Demo.Eto;
using Yan.Demo.Request;
using Yan.Demo.Service;

namespace Yan.Demo.Implement;

public class PublisherService : DemoAppService, IPublisherService
{
    #region Fields
    private readonly IDistributedEventBus _distributedEventBus;
    #endregion

    #region Constructors
    public PublisherService(IDistributedEventBus distributedEventBus) => _distributedEventBus = distributedEventBus;
    #endregion

    #region Implements
    public async Task Shoot(MessageRequest request) => await _distributedEventBus.PublishAsync(ObjectMapper.Map<MessageRequest, MessageEto>(request));
    #endregion
}
