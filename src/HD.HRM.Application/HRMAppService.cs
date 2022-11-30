using System;
using System.Collections.Generic;
using System.Text;
using HD.HRM.Localization;
using Volo.Abp.Application.Services;

namespace HD.HRM;

/* Inherit your application services from this class.
 */
public abstract class HRMAppService : ApplicationService
{
    protected HRMAppService()
    {
        LocalizationResource = typeof(HRMResource);
    }
}
