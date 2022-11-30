using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HD.Profiles.EntityFrameworkCore;

[ConnectionStringName(ProfilesDbProperties.ConnectionStringName)]
public interface IProfilesDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
