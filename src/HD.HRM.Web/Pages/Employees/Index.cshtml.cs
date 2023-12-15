using HD.Profiles.Employees;
using HD.Profiles.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Domain.Repositories;

namespace HD.Profiles.Web.Pages.Employees
{
    public class IndexModel : ProfilesPageModel
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IOrganizationAppService _organizationAppService;
        public PagedResultDto<EmployeeDto> Result { get; set; }
        public List<OrganizationDto> Organizations { get; set; }
        public OrganizationDto Organization { get; set; }

        public HrmRequestDto Params = new HrmRequestDto();
        
        public string View { get; set; }
        public IndexModel(IEmployeeAppService employeeAppService, IOrganizationAppService organizationAppService)
        {
            _employeeAppService = employeeAppService;
            _organizationAppService = organizationAppService;
        }

        public async Task OnGetAsync(HrmRequestDto input)
        {
            Params = input;
            Result = await _employeeAppService.GetListAsync(input);
            Organizations = await _organizationAppService.GetListSubOrganizationAsync(null);
        }
    }
}
