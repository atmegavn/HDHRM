using HD.Profiles.Organizations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HD.Profiles.Jobs
{
    public interface IJobAppService : IApplicationService
    {
        Task<JobDto> GetAsync(Guid id);
        Task<PagedResultDto<JobDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<JobFamilyDto>> GetListJobFamiliesAsync(PagedAndSortedResultRequestDto input);
        Task<JobDto> CreateAsync(CreateJobDto form);

        Task<ListResultDto<JobFamiliesLookupDto>> GetJobFamiliesLookupAsync();
    }
}
