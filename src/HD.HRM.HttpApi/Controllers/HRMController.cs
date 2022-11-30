using HD.HRM.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HD.HRM.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HRMController : AbpControllerBase
{
    protected HRMController()
    {
        LocalizationResource = typeof(HRMResource);
    }
}
