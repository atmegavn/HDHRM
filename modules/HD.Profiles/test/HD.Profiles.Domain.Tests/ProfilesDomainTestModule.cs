using HD.Profiles.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HD.Profiles;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(ProfilesEntityFrameworkCoreTestModule)
    )]
public class ProfilesDomainTestModule : AbpModule
{

}
