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
using HD.Profiles.Skills;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace HD.Profiles.EntityFrameworkCore;

public static class ProfilesDbContextModelCreatingExtensions
{
    public static void ConfigureProfiles(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Decision>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Decision", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Number).IsRequired();
            b.Property(p => p.TypeId).IsRequired();
            b.Property(p => p.OrganizationId).IsRequired();
            //Relations
            b.HasOne(p => p.DecisionMaker).WithMany().HasForeignKey(p => p.DecisionMakerId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.DecisionType).WithMany().HasForeignKey(p => p.TypeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.DecisionReceiver).WithMany().HasForeignKey(p => p.DecisionReceiverId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<DecisionType>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "DecisionType", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
        });

        builder.Entity<Contract>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Contract", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Number).IsRequired();
            b.Property(p => p.CategoryId).IsRequired();
            //Relations
            b.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<ContractCategory>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "ContractCategory", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
        });

        builder.Entity<Employee>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Employee", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Code).IsRequired();
            b.Property(p => p.UserId).IsRequired(false);
            b.Property(p => p.StatusId).IsRequired(false);

            //Relations
            b.HasOne(p => p.JobTitle).WithMany().HasForeignKey(p => p.JobTitleId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.Status).WithMany().HasForeignKey(p => p.StatusId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.Positions).WithOne().HasForeignKey(r => r.EmployeeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.Relatives).WithOne().HasForeignKey(r => r.EmployeeId).OnDelete(DeleteBehavior.NoAction).IsRequired();

        });

        builder.Entity<Job>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Job", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Level).IsRequired();
            //Relations
            b.HasOne(p => p.JobFamily).WithMany().HasForeignKey(p => p.JobFamilyId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<JobFamily>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "JobFamily", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.ParentId).IsRequired(false);
            //Relations
            b.HasOne(p => p.Parent).WithMany(p => p.Childs).HasForeignKey(p => p.ParentId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.Jobs).WithOne(p => p.JobFamily).HasForeignKey(r => r.JobFamilyId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<JobTitle>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "JobTitle", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
        });

        builder.Entity<District>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "District", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            //Relations
            b.HasOne(p => p.Provincial).WithMany().HasForeignKey(p => p.ProvincialId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<Provincial>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Provincial", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            //Relations
            b.HasOne(p => p.National).WithMany().HasForeignKey(p => p.NationalId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<Street>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Street", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            //Relations
            b.HasOne(p => p.Village).WithMany().HasForeignKey(p => p.VillageId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<Village>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Village", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            //Relations
            b.HasOne(p => p.District).WithMany().HasForeignKey(p => p.DistrictId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<National>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "National", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Code).IsRequired();
        });

        builder.Entity<Location>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Location", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Address).IsRequired();
            //Relations
            b.HasOne(p => p.Street).WithMany().HasForeignKey(p => p.StreetId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.Village).WithMany().HasForeignKey(p => p.VillageId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.District).WithMany().HasForeignKey(p => p.DistrictId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.Provincial).WithMany().HasForeignKey(p => p.ProvincialId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.National).WithMany().HasForeignKey(p => p.NationalId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<JobPosition>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "JobPosition", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.OrganizationId).IsRequired();
            b.Property(p => p.JobId).IsRequired();
            
            b.Property(p => p.EmployeeId).IsRequired(false);

            //Relations
            b.HasOne(p => p.Organization).WithMany(o => o.Positions).HasForeignKey(p => p.OrganizationId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.Job).WithMany().HasForeignKey(p => p.JobId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<Organization>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Organization", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Code).IsRequired();
            b.Property(p => p.ParentId).IsRequired(false);

            //Relations
            b.HasMany(p => p.Positions).WithOne(p => p.Organization).HasForeignKey(r => r.OrganizationId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.Contacts).WithOne().HasForeignKey(r => r.OrganizationId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.Address).WithOne().HasForeignKey(r => r.OrganizationId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.BankAccounts).WithOne().HasForeignKey(r => r.OrganizationId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.Parent).WithMany().HasForeignKey(p => p.ParentId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<Bank>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Bank", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
        });

        builder.Entity<Account>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Account", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
        });

        builder.Entity<Contact>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Contact", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Content).IsRequired();
            //Relations
            b.HasOne(p => p.ContactProvider).WithMany().HasForeignKey(p => p.ContactProviderId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<ContactProvider>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "ContactProvider", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
        });

        builder.Entity<Relationship>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Relationship", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
        });

        builder.Entity<Relative>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Relative", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            //Relations
            b.HasOne(p => p.Relationship).WithMany().HasForeignKey(p => p.RelationshipId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<Address>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Address", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.LocationId).IsRequired();
            //Relations
            b.HasOne(p => p.Location).WithMany().HasForeignKey(p => p.LocationId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<IdCard>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "IdCard", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Number).IsRequired();
            b.Property(p => p.FullName).IsRequired();
            b.Property(p => p.DateOfBith).IsRequired();
            b.Property(p => p.Gender).IsRequired();
            //Relations
        });

        builder.Entity<Profile>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Profile", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.FirstName).IsRequired();
            b.Property(p => p.SurName).IsRequired();
            b.Property(p => p.GivenName).IsRequired();
            b.Property(p => p.Gender).IsRequired();
            //Relations
            b.HasOne(p => p.ProfileType).WithMany().HasForeignKey(p => p.ProfileTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.Cards).WithOne().HasForeignKey(r => r.ProfileId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.Address).WithOne().HasForeignKey(r => r.ProfileId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.Contacts).WithOne().HasForeignKey(r => r.ProfileId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.BankAccounts).WithOne().HasForeignKey(r => r.ProfileId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<ProfileType>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "ProfileType", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
        });

        builder.Entity<Skill>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfilesDbProperties.DbTablePrefix + "Skill", ProfilesDbProperties.DbSchema);
            b.ConfigureByConvention();
            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
        });
    }
}
