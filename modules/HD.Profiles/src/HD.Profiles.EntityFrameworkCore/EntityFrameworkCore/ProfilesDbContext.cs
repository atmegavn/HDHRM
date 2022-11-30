using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HD.Profiles.EntityFrameworkCore;

[ConnectionStringName(ProfilesDbProperties.ConnectionStringName)]
public class ProfilesDbContext : AbpDbContext<ProfilesDbContext>, IProfilesDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ProfilesDbContext(DbContextOptions<ProfilesDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureProfiles();
    }
}
