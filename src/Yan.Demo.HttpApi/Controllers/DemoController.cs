using Volo.Abp.AspNetCore.Mvc;
using Yan.Demo.Localization;

namespace Yan.Demo.Controllers;

public abstract class DemoController : AbpControllerBase
{
    protected DemoController() => LocalizationResource = typeof(DemoResource);
}
