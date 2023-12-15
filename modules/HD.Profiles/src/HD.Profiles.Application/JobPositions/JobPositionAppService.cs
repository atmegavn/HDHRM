using HD.Profiles.Employees;
using HD.Profiles.Jobs;
using HD.Profiles.Organizations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HD.Profiles.JobPositions
{
    public class JobPositionAppService : ProfilesAppService, IJobPositionAppService
    {
        private readonly IRepository<JobPosition, Guid> _jobPositionRepository;
        public JobPositionAppService(IRepository<JobPosition, Guid> jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        }
        Task<JobPositionDto> IJobPositionAppService.CreateAsync(CreateJobPositionDto form)
        {
            throw new NotImplementedException();
        }

        async Task<JobPositionDto> IJobPositionAppService.GetAsync(Guid id)
        {
            var queryable = await _jobPositionRepository.WithDetailsAsync(e => e.Job);
            queryable = queryable.Include(e => e.Organization);
            queryable = queryable.Include(e => e.Decision);
            queryable = queryable.Where(e => e.Id == id);
            var data = await AsyncExecuter.FirstOrDefaultAsync(queryable);
            var result = ObjectMapper.Map <JobPosition, JobPositionDto>(data);
            return result;
        }

        Task<ListResultDto<JobFamiliesLookupDto>> IJobPositionAppService.GetJobFamiliesLookupAsync()
        {
            throw new NotImplementedException();
        }

        Task<PagedResultDto<JobPositionDto>> IJobPositionAppService.GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        Task<PagedResultDto<JobFamilyDto>> IJobPositionAppService.GetListJobFamiliesAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }
    }
}
