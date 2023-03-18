using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Yan.Demo.Requests;

namespace Yan.Demo.Services;

public interface IPublisherService : IApplicationService
{
    public Task Shoot(MessageRequest request);
}
