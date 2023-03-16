using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Yan.Demo.Request;

namespace Yan.Demo.Service;

public interface IPublisherService : IApplicationService
{
    public Task Shoot(MessageRequest request);
}
