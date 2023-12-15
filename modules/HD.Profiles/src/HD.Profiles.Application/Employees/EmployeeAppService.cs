using HD.Profiles.Jobs;
using HD.Profiles.Organizations;
using HD.Profiles.Samples;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace HD.Profiles.Employees
{
    public class EmployeeAppService : ProfilesAppService, IEmployeeAppService
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<Organization, Guid> _organizationRepository;

        public EmployeeAppService(IRepository<Employee, Guid> employeeRepository, IRepository<Organization, Guid> organizationRepository) { 
            _employeeRepository = employeeRepository;
            _organizationRepository = organizationRepository;   
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto input)
        {
            var employee = new Employee();
            employee.Code = input.Code;
            employee.Name = input.Name;
            employee.DateOfOnboard = input.DateOfOnboard;
            employee.JobTitleId = input.JobTitleId;
            employee.Email = input.Email;
            employee.Mobile = input.Mobile;
            await _employeeRepository.InsertAsync(employee);
         
           return ObjectMapper.Map<Employee, EmployeeDto>(employee);
        }

        async Task<PagedResultDto<EmployeeDto>> IEmployeeAppService.GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //var queryable = await _employeeRepository.GetQueryableAsync();
            var queryable = await _employeeRepository.WithDetailsAsync(e => e.Positions);
            queryable = queryable.Include(e => e.JobTitle);
            queryable = queryable.OrderByDescending(e => e.CreationTime).Skip(input.SkipCount).Take(input.MaxResultCount);

            var data = await AsyncExecuter.ToListAsync(queryable);
            var count = await _employeeRepository.GetCountAsync();

            var result = new PagedResultDto<EmployeeDto>(count, ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(data));
            return result;
        }

        public async Task<ListResultDto<OrganizationLookupDto>> GetOrganizationAsync(Guid? rootOrgId)
        {
            var orgs = await _organizationRepository.GetListAsync();
            return new ListResultDto<OrganizationLookupDto>(ObjectMapper.Map<List<Organization>, List<OrganizationLookupDto>>(orgs));
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDto> GetAsync(Guid id)
        {
            var queryable = await _employeeRepository.WithDetailsAsync(e => e.Positions);
            queryable = queryable.Include(e => e.JobTitle).Where(e => e.Id == id);
            var data = await AsyncExecuter.FirstOrDefaultAsync(queryable);
            var result = ObjectMapper.Map<Employee, EmployeeDto>(data);
            return result;
        }

        public Task UpdateAsync(Guid id, UpdateEmployeeDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResultDto<EmployeeLookupDto>> GetEmployeeLookupAsync(List<Guid> ids)
        {
            if(ids.Count > 0)
            {
                var queryable = await _employeeRepository.GetQueryableAsync();
                queryable = queryable.Where(e => ids.Contains(e.Id));
                var data = await AsyncExecuter.ToListAsync(queryable);
                return new ListResultDto<EmployeeLookupDto>(ObjectMapper.Map<List<Employee>, List<EmployeeLookupDto>>(data));
            }
            else
            {
                var employee = await _employeeRepository.GetListAsync();
                return new ListResultDto<EmployeeLookupDto>(ObjectMapper.Map<List<Employee>, List<EmployeeLookupDto>>(employee));
            }
            
        }
    }
}
