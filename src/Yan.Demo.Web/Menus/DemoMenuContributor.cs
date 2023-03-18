using System.Threading.Tasks;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Yan.Demo.Localization;
using static System.Threading.Tasks.Task;
using static Volo.Abp.TenantManagement.Web.Navigation.TenantManagementMenuNames;
using static Volo.Abp.UI.Navigation.StandardMenus;
using static Yan.Demo.MultiTenancy.MultiTenancyConsts;
using static Yan.Demo.Web.Menus.DemoMenus;

namespace Yan.Demo.Web.Menus;

public class DemoMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        context.Menu.Items.Insert(0, new ApplicationMenuItem(Home, context.GetLocalizer<DemoResource>()["Menu:Home"], "~/", icon: "fas fa-home", order: 0));
        if (IsEnabled)
        {
            _ = administration.SetSubItemOrder(GroupName, 1);
        }
        _ = administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        _ = administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        return CompletedTask;
    }
}
