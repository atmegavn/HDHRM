using HD.Profiles.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HD.Profiles.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ProfilesPageModel : AbpPageModel
{
    protected ProfilesPageModel()
    {
        LocalizationResourceType = typeof(ProfilesResource);
        ObjectMapperContext = typeof(ProfilesWebModule);
    }
}
