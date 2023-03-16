using Yan.Demo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Yan.Demo.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class DemoPageModel : AbpPageModel
{
    protected DemoPageModel()
    {
        LocalizationResourceType = typeof(DemoResource);
    }
}
