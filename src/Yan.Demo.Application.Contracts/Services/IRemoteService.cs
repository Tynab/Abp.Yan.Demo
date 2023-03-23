using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Yan.Demo.Services;

public interface IRemoteService : IApplicationService
{
    public Task Test();
}
