using HD.Profiles.Jobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Profiles.Web.Pages.JobPositions
{
    public class CreateModel : ProfilesPageModel
    {
        public CreateJobDto Form { get; set; }
        public string BackUrl { get; set; }
        public List<SelectListItem> JobFamiliesLookup { get; set; }
        public readonly IJobAppService _jobPositionAppService;
        public CreateModel(IJobAppService jobPositionAppService)
        {
            _jobPositionAppService = jobPositionAppService;
        }
        public async Task OnGetAsync(string backUrl)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
            Form = new CreateJobDto();
            var positionLookUp = await _jobPositionAppService.GetJobFamiliesLookupAsync();
            JobFamiliesLookup = positionLookUp.Items.Select(p => new SelectListItem(p.Name, p.Id.ToString())).ToList();
        }

        public async Task<ActionResult> OnPostAsync(CreateJobDto form)
        {
            if (!ModelState.IsValid)
            {
                Form = form;
                ViewData["Exception"] = "Form Invalid";
                return Page();
            }

            var insert = _jobPositionAppService.CreateAsync(form);
            if (insert.IsCompletedSuccessfully)
            {
                return RedirectToPage("Detail", new { id = insert.Result.Id });
            }
            else
            {
                Form = form;
                ViewData["Exception"] = insert.Exception.ToString();
                return Page();
            }
        }
    }
}
