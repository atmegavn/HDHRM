using Volo.Abp.Reflection;

namespace HD.Profiles.Permissions;

public class ProfilesPermissions
{
    public const string GroupName = "Profiles";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProfilesPermissions));
    }
}
