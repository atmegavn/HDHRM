using HD.Profiles.Employees;
using HD.Profiles.Jobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HD.Profiles.Organizations
{
    public interface IOrganizationAppService : IApplicationService
    {
        Task<OrganizationDto> GetAsync(Guid id);
        Task<PagedResultDto<OrganizationDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<OrganizationDto> CreateAsync(CreateOrganizationDto input);
        Task<List<OrganizationDto>> GetListSubOrganizationAsync(Guid? id);
        Task<ListResultDto<JobLookupDto>> GetJobLookupAsync();
        Task<OrganizationDto> UpdateAsync(Guid id, OrganizationDto input);
        Task AddPositionAsync(AddPositionDto input);
        Task UpdatePositionAsync(AppointmentDto input);
        Task<List<JobPositionDto>> ListPositionsOfOrganization(Guid id, Guid? jobPositionId = null);
        Task DeleteAsync(Guid id);
        Task<JobPositionDto> GetOrganizationPositionAsync(Guid id);
        Task<OrganizationDto> GetOrgWithFullChildrents(Guid id);
    }
}
