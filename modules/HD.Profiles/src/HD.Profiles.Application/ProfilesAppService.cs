using HD.Profiles.Localization;
using Volo.Abp.Application.Services;

namespace HD.Profiles;

public abstract class ProfilesAppService : ApplicationService
{
    protected ProfilesAppService()
    {
        LocalizationResource = typeof(ProfilesResource);
        ObjectMapperContext = typeof(ProfilesApplicationModule);
    }
}
