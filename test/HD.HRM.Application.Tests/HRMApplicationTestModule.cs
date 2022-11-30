using Volo.Abp.Modularity;

namespace HD.HRM;

[DependsOn(
    typeof(HRMApplicationModule),
    typeof(HRMDomainTestModule)
    )]
public class HRMApplicationTestModule : AbpModule
{

}
