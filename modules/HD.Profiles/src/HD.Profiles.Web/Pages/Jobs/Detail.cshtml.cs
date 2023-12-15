using HD.Profiles.Jobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace HD.Profiles.Web.Pages.Jobs
{
    public class DetailModel : PageModel
    {
        public JobDto Form { get; set; }
        public string BackUrl { get; set; }
        public readonly IJobAppService _jobPositionAppService;

        public DetailModel(IJobAppService jobPositionAppService)
        {
            _jobPositionAppService = jobPositionAppService;
        }

        public async Task OnGetAsync(Guid id, string backUrl)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
            Form = await _jobPositionAppService.GetAsync(id);
        }
    }
}
