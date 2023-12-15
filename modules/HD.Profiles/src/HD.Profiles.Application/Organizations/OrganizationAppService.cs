using HD.Profiles.Jobs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HD.Profiles.Organizations
{
    public class OrganizationAppService : ProfilesAppService, IOrganizationAppService
    {
        //private readonly IOrganizationRepository _organizationRepository;
        private readonly IRepository<Organization,Guid> _organizationRepository;
        private readonly IRepository<JobPosition,Guid> _jobPositionRepository;
        private readonly IRepository<Job,Guid> _jobRepository;

        public OrganizationAppService(
            IRepository<Organization,Guid> organizationRepository, 
            IRepository<JobPosition, Guid> jobPositionRepository, 
            IRepository<Job, Guid> jobRepository)
        {
            _organizationRepository = organizationRepository;
            _jobPositionRepository = jobPositionRepository;
            _jobRepository = jobRepository;   
        }

        public async Task<OrganizationDto> CreateAsync(CreateOrganizationDto input)
        {
            //var org = ObjectMapper.Map<CreateOrganizationDto, Organization>(input);
            var org = new Organization();
            org.Code = input.Code;
            org.Name = input.Name;
            org.Phone = input.Phone;
            org.Email = input.Email;
            org.Level = input.Level;
            org.ParentId = input.ParentId;
            org.Description = input.Description;
            org.Location = input.Location;
            org.CreatedDate = input.CreatedDate;
            await _organizationRepository.InsertAsync(org);

            return ObjectMapper.Map<Organization, OrganizationDto>(org);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _organizationRepository.DeleteAsync(id);
        }

        public async Task<OrganizationDto> GetAsync(Guid id)
        {
            var queryable = await _organizationRepository
                .WithDetailsAsync(o => o.Positions.Where(p => p.Job.JobFamily.Name == "Management" || p.Job.JobFamily.Name == "Charman"));
            queryable = queryable.Where(o => o.Id == id);
            var data = await AsyncExecuter.FirstOrDefaultAsync(queryable);
            var result = ObjectMapper.Map<Organization, OrganizationDto>(data);
            return result;
        }

        public async Task<List<OrganizationDto>> GetListSubOrganizationAsync(Guid? id)
        {
            var queryable = await _organizationRepository.WithDetailsAsync(o => o.Childrent);
            queryable = queryable.Where(o => o.ParentId == id).OrderByDescending(o => o.Name);
            var data = await AsyncExecuter.ToListAsync(queryable);

            var result = ObjectMapper.Map<List<Organization>, List<OrganizationDto>>(data);
            return result;
        }

        public async Task<PagedResultDto<OrganizationDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _organizationRepository.WithDetailsAsync(o => o.Positions);
            var paged = queryable.Where(o => !o.ParentId.HasValue).Skip(input.SkipCount).Take(input.MaxResultCount).OrderByDescending(e => e.Name);
            var data = await AsyncExecuter.ToListAsync(paged);
            //var data = await paged.ToListAsync();

            var count = await _organizationRepository.CountAsync(p => p.ParentId == null) ;
            return new PagedResultDto<OrganizationDto>(count, ObjectMapper.Map<List<Organization>, List<OrganizationDto>>(data));
        }

        public async Task<OrganizationDto> UpdateAsync(Guid id, OrganizationDto input)
        {
            var org = await _organizationRepository.GetAsync(id);
            org.Code = input.Code;
            org.Name = input.Name;
            org.Phone = input.Phone;
            org.Email = input.Email;
            org.Description = input.Description;
            org.Location = input.Location;
            org.CreatedDate = input.CreatedDate;

            var updatedOrg = await _organizationRepository.UpdateAsync(org);

            return ObjectMapper.Map<Organization, OrganizationDto>(updatedOrg);
        }

        public async Task<ListResultDto<JobLookupDto>> GetJobLookupAsync()
        {
            var positions = await _jobRepository.GetListAsync();
            return new ListResultDto<JobLookupDto>(ObjectMapper.Map<List<Job>, List<JobLookupDto>>(positions));
        }

        public async Task AddPositionAsync(AddPositionDto input)
        {
            var positions = new List<JobPosition>();
            if (input.Amount > 0)
            {
                var amount = input.Amount;
                while (amount > 0)
                {
                    var newPosition = new JobPosition()
                    {
                        Name = input.Name,
                        JobId = input.JobPositionId,
                        OrganizationId = input.OrganizationId
                    };
                    positions.Add(newPosition);
                    amount--;
                }
            }

            await _jobPositionRepository.InsertManyAsync(positions);
        }

        public async Task UpdatePositionAsync(AppointmentDto input)
        {
            var position = await _jobPositionRepository.GetAsync(input.Id);
            position.Name = input.Name;
            position.EmployeeId = input.EmployeeId;

            await _jobPositionRepository.UpdateAsync(position);
        }

        public async Task<List<JobPositionDto>> ListPositionsOfOrganization(Guid id, Guid? jobPositionId)
        {
            var queryable = await _jobPositionRepository.WithDetailsAsync(op => op.Job);
            if (jobPositionId.HasValue)
            {
                queryable = queryable.Where(op => op.JobId == jobPositionId);
            }
            //queryable = queryable.Where(op => op.Job.JobFamily.Name != "Management" && op.Job.JobFamily.Name != "Charman").Where(op => op.OrganizationId == id).OrderBy(op => op.Name);
            queryable = queryable.Where(op => op.OrganizationId == id).OrderBy(op => op.Name);
            //queryable = queryable.Where(op => op.OrganizationId == id).OrderBy(op => op.Name);
            var data = await AsyncExecuter.ToListAsync(queryable);

            var result = ObjectMapper.Map<List<JobPosition>, List<JobPositionDto>>(data);

            return result;
        }

        public async Task<JobPositionDto> GetOrganizationPositionAsync(Guid id)
        {
            var queryable = await _jobPositionRepository.WithDetailsAsync(o => o.Job);
            queryable = queryable.Include(o => o.Organization);
            queryable = queryable.Where(o => o.Id == id);
            var data = await AsyncExecuter.FirstOrDefaultAsync(queryable);
            var result = ObjectMapper.Map<JobPosition, JobPositionDto>(data);
            return result;
        }

        public async Task<OrganizationDto> GetOrgWithFullChildrents(Guid id) { 
            var queryable = await _organizationRepository.WithDetailsAsync(o => o.Childrent);
            queryable = queryable.Where(o => o.Id == id);
            var data = await AsyncExecuter.FirstOrDefaultAsync(queryable);
            var result = ObjectMapper.Map<Organization, OrganizationDto>(data);
            return result;
        }
    }
}
