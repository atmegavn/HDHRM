using HD.Profiles.Jobs;
using HD.Profiles.Organizations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HD.Profiles.JobPositions
{
    public interface IJobPositionAppService: IApplicationService
    {
        Task<JobPositionDto> GetAsync(Guid id);
        Task<PagedResultDto<JobPositionDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<JobFamilyDto>> GetListJobFamiliesAsync(PagedAndSortedResultRequestDto input);
        Task<JobPositionDto> CreateAsync(CreateJobPositionDto form);

        Task<ListResultDto<JobFamiliesLookupDto>> GetJobFamiliesLookupAsync();
    }
}
