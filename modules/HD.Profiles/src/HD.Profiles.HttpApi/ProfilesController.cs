using HD.Profiles.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HD.Profiles;

public abstract class ProfilesController : AbpControllerBase
{
    protected ProfilesController()
    {
        LocalizationResource = typeof(ProfilesResource);
    }
}
