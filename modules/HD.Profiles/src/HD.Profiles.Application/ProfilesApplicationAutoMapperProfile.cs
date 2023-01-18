using AutoMapper;
using HD.Profiles.Employees;
using HD.Profiles.Jobs;
using HD.Profiles.JobTitles;
using HD.Profiles.Organizations;

namespace HD.Profiles;

public class ProfilesApplicationAutoMapperProfile : Profile
{
    public ProfilesApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Employee, EmployeeDto>();
        CreateMap<Organization, OrganizationDto>();

        CreateMap<JobPosition, JobPositionDto>();
        CreateMap<JobPosition, PositionLookupDto>();
        CreateMap<JobFamily, JobFamilyDto>();
        CreateMap<JobFamily, JobFamiliesLookupDto>();
        CreateMap<Job, JobDto>();
        CreateMap<Job, JobLookupDto>();

        CreateMap<JobTitle, JobTitleDto>();
        CreateMap<JobTitle, JobTitleLookupDto>();

        CreateMap<JobPosition, JobPositionDto>();

        CreateMap<Employee, EmployeeDto>();
        CreateMap<Employee, EmployeeLookupDto>();
    }
}
