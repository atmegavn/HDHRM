using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace HD.Profiles;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProfilesDomainSharedModule)
)]
public class ProfilesDomainModule : AbpModule
{

}
