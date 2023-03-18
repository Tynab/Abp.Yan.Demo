using Volo.Abp.Authorization.Permissions;
using static Yan.Demo.Permissions.DemoPermissions;

namespace Yan.Demo.Permissions;

public class DemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context) => context.AddGroup(GroupName);
}
