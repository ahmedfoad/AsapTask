using AsapTask.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AsapTask.Permissions;

public class AsapTaskPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AsapTaskPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AsapTaskPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AsapTaskResource>(name);
    }
}
