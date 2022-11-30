using Volo.Abp.Modularity;

namespace HD.Profiles;

[DependsOn(
    typeof(ProfilesApplicationModule),
    typeof(ProfilesDomainTestModule)
    )]
public class ProfilesApplicationTestModule : AbpModule
{

}
