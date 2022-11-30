using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace HD.HRM.Web;

[Dependency(ReplaceServices = true)]
public class HRMBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "HRM";
}
