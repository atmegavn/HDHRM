using HD.Profiles.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HD.Profiles.Permissions;

public class ProfilesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProfilesPermissions.GroupName, L("Permission:Profiles"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProfilesResource>(name);
    }
}
