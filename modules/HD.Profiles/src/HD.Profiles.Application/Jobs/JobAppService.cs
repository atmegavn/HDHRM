using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace HD.Profiles.Jobs
{
    public class JobAppService: ProfilesAppService, IJobAppService
    {
        private readonly IRepository<Job, Guid> _jobRepository;
        private readonly IRepository<JobFamily, Guid> _jobFamilyRepository;

        public JobAppService(IRepository<Job, Guid> jobRepository, IRepository<JobFamily, Guid> jobFamilyRepository) {
            _jobRepository = jobRepository;
            _jobFamilyRepository = jobFamilyRepository;
        }

        public async Task<JobDto> CreateAsync(CreateJobDto form)
        {
            var job = new Job();
            job.Name = form.Name;
            job.Description = form.Description;
            job.JobFamilyId = form.JobFamilyId;
            job.Requirement = form.Requirement;
            await _jobRepository.InsertAsync(job);

            return ObjectMapper.Map<Job, JobDto>(job);
        }

        public async Task<JobDto> GetAsync(Guid id)
        {
            var data = await _jobRepository.GetAsync(id);
            return ObjectMapper.Map<Job, JobDto>(data);
        }

        public async Task<PagedResultDto<JobDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _jobRepository.WithDetailsAsync(j => j.JobFamily);
            queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount);

            var data = await AsyncExecuter.ToListAsync(queryable);
            var count = await _jobRepository.GetCountAsync();

            var result = new PagedResultDto<JobDto>(count, ObjectMapper.Map<List<Job>, List<JobDto>>(data));
            return result;
        }

        public async Task<ListResultDto<JobFamiliesLookupDto>> GetJobFamiliesLookupAsync()
        {
            var jobFamilies = await _jobFamilyRepository.GetListAsync();
            return new ListResultDto<JobFamiliesLookupDto>(ObjectMapper.Map<List<JobFamily>, List<JobFamiliesLookupDto>>(jobFamilies));
        }

        public async Task<PagedResultDto<JobFamilyDto>> GetListJobFamiliesAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _jobFamilyRepository.GetQueryableAsync();
            queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount);

            var data = await AsyncExecuter.ToListAsync(queryable);
            var count = await _jobRepository.GetCountAsync();

            var result = new PagedResultDto<JobFamilyDto>(count, ObjectMapper.Map<List<JobFamily>, List<JobFamilyDto>>(data));
            return result;
        }
    }
}
