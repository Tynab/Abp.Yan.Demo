using Volo.Abp.Application.Services;
using Yan.Demo.Localization;

namespace Yan.Demo;

public abstract class DemoAppService : ApplicationService
{
    protected DemoAppService() => LocalizationResource = typeof(DemoResource);
}
