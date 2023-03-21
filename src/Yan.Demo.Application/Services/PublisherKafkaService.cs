using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Kafka;
using Yan.Demo.Etos;
using Yan.Demo.Requests;

namespace Yan.Demo.Services;

public class PublisherKafkaService : DemoAppService, IPublisherKafkaService
{
    #region Fields
    private readonly KafkaDistributedEventBus _distributedEventBus;
    #endregion

    #region Constructors
    public PublisherKafkaService(KafkaDistributedEventBus distributedEventBus) => _distributedEventBus = distributedEventBus;
    #endregion

    #region Implements
    public async Task Shoot(MessageRequest request) => await _distributedEventBus.PublishAsync(ObjectMapper.Map<MessageRequest, MessageEto>(request));
    #endregion
}
