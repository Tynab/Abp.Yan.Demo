using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.RabbitMq;
using Yan.Demo.Etos;
using Yan.Demo.Requests;

namespace Yan.Demo.Services;

public class PublisherRabbitmqService : DemoAppService, IPublisherRabbitmqService
{
    #region Fields
    private readonly RabbitMqDistributedEventBus _distributedEventBus;
    #endregion

    #region Constructors
    public PublisherRabbitmqService(RabbitMqDistributedEventBus distributedEventBus) => _distributedEventBus = distributedEventBus;
    #endregion

    #region Implements
    public async Task Shoot(MessageRequest request) => await _distributedEventBus.PublishAsync(ObjectMapper.Map<MessageRequest, MessageEto>(request));
    #endregion
}
