using HD.Profiles.Contacts;
using HD.Profiles.Decisions;
using HD.Profiles.Employees;
using HD.Profiles.Employees.Contracts;
using HD.Profiles.Jobs;
using HD.Profiles.Locations;
using HD.Profiles.Organizations;
using HD.Profiles.Profiles;
using HD.Profiles.Profiles.Banks;
using HD.Profiles.Profiles.Relatives;
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

    public DbSet<Decision> Decision { get; set; }
    public DbSet<DecisionType> DecisionType { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Contract> Contract { get; set; }
    public DbSet<ContractCategory> ContractCategory { get; set; }
    public DbSet<Job> Job { get; set; }
    public DbSet<JobFamily> JobFamily { get; set; }
    public DbSet<JobTitle> JobTitle { get; set; }
    public DbSet<Location> Location { get; set; }
    public DbSet<District> District { get; set; }
    public DbSet<National> National { get; set; }
    public DbSet<Provincial> Provincial { get; set; }
    public DbSet<Street> Street { get; set; }
    public DbSet<Village> Village { get; set; }
    public DbSet<Organization> Organization { get; set; }
    public DbSet<JobPosition> JobPosition { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<Bank> Bank { get; set; }
    public DbSet<Contact> Contact { get; set; }
    public DbSet<ContactProvider> ContactProvider { get; set; }
    public DbSet<Relationship> Relationship { get; set; }
    public DbSet<Relative> Relative { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<IdCard> IdCard { get; set; }
    public DbSet<Profile> Profile { get; set; }
    public DbSet<ProfileType> ProfileType { get; set; }

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
