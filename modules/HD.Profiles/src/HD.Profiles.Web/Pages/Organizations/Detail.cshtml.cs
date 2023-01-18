using HD.Profiles.Employees;
using HD.Profiles.Organizations;
using HD.Profiles.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HD.ProfileManager.Web.Pages.Organizations
{
    public class DetailModel : ProfilesPageModel
    {
        public OrganizationDto Form { get; set; }
        public List<OrganizationDto> Organizations { get; set; }
        public List<JobPositionDto> Positions { get; set; }
        public ListResultDto<EmployeeLookupDto> EmployeeLoockup { get; set; }
        public Guid? PositionId { get; set; }
        public string BackUrl { get; set; }
        private readonly IOrganizationAppService _organizationAppService;
        private readonly IEmployeeAppService _employeeAppService;
        public DetailModel(IOrganizationAppService organizationAppService, IEmployeeAppService employeeAppService)
        {
            _organizationAppService = organizationAppService;
            _employeeAppService = employeeAppService;
        }

        public async Task OnGetAsync(Guid id, string backUrl, Level level)
        {
            Form = await _organizationAppService.GetAsync(id);
            Organizations = await _organizationAppService.GetListSubOrganizationAsync(id);
            Positions = await _organizationAppService.ListPositionsOfOrganization(id);
            var eids = Form.Positions.Where(p => p.EmployeeId.HasValue).Select(p => p.EmployeeId.Value).Distinct().ToList();
            EmployeeLoockup = await _employeeAppService.GetEmployeeLookupAsync(eids);
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
        }
    }
}
