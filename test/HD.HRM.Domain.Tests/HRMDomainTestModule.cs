using HD.HRM.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HD.HRM;

[DependsOn(
    typeof(HRMEntityFrameworkCoreTestModule)
    )]
public class HRMDomainTestModule : AbpModule
{

}
