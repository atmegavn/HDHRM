using HD.Profiles.JobPositions;
using HD.Profiles.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace HD.Profiles.Web.Pages.Organizations
{
    public class PositionEditModel : PageModel
    {
        public string BackUrl { get; set; }
        public JobPositionDto Form { get; set; }
        private readonly IJobPositionAppService _jobPositionAppService;
        public PositionEditModel(IJobPositionAppService jobPositionAppService)
        {
            _jobPositionAppService= jobPositionAppService;
        }
        public async Task OnGetAsync(Guid id, string backUrl)
        {
            Form = await _jobPositionAppService.GetAsync(id);
            BackUrl = backUrl;
        }
    }
}
