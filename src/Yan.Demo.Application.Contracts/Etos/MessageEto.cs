using Volo.Abp.EventBus;

namespace Yan.Demo.Etos;

[EventName("yan.demo")]
public class MessageEto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
}
