using HD.Profiles.JobPositions;
using HD.Profiles.Jobs;
using HD.Profiles.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD.Profiles.Web.Pages.Organizations
{
    public class PositionListModel : ProfilesPageModel
    {
        public JobDto Form { get; set; }
        public List<JobPositionDto> Positions { get; set; }
        public string OrgName { get; set; }
        public Guid OrgId { get; set; }

        public string BackUrl { get; set; }
        private readonly IOrganizationAppService _organizationAppService;
        private readonly IJobAppService _jobAppService;

        public PositionListModel(IOrganizationAppService organizationAppService, IJobAppService jobAppService)
        {
            _organizationAppService = organizationAppService;
            _jobAppService = jobAppService;
        }
        public async Task OnGetAsync(Guid id, Guid orgId, string backUrl)
        {
            Form = await _jobAppService.GetAsync(id);
            Positions = await _organizationAppService.ListPositionsOfOrganization(orgId, id);
            var org = await _organizationAppService.GetAsync(orgId);
            OrgName = org.Name;
            OrgId = org.Id;
            BackUrl = backUrl;
        }
    }
}
