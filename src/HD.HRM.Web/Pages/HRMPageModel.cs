using HD.HRM.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HD.HRM.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class HRMPageModel : AbpPageModel
{
    protected HRMPageModel()
    {
        LocalizationResourceType = typeof(HRMResource);
    }
}
