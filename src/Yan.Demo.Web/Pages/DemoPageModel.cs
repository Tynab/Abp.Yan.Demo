using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Yan.Demo.Localization;

namespace Yan.Demo.Web.Pages;

public abstract class DemoPageModel : AbpPageModel
{
    protected DemoPageModel() => LocalizationResourceType = typeof(DemoResource);
}
