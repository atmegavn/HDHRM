using HD.Profiles.Jobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using HD.Profiles.Organizations;

namespace HD.Profiles.Web.Pages.Jobs
{
    public class EditModel : PageModel
    {
        public JobDto Form { get; set; }
        public string BackUrl { get; set; }
        public readonly IJobAppService _jobPositionAppService;
        public List<SelectListItem> JobFamiliesLookup { get; set; }
        public EditModel(IJobAppService jobPositionAppService) {
            _jobPositionAppService = jobPositionAppService;
        }
        public async Task OnGetAsync(Guid id, string backUrl)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Detail" : backUrl;
            Form = await _jobPositionAppService.GetAsync(id);

            var positionLookUp = await _jobPositionAppService.GetJobFamiliesLookupAsync();
            JobFamiliesLookup = positionLookUp.Items.Select(p => new SelectListItem(p.Name, p.Id.ToString())).ToList();
        }

        public async Task<ActionResult> OnPostAsync(JobDto form)
        {
            if (!ModelState.IsValid)
            {
                Form = form;
                ViewData["Exception"] = "Form Invalid";
                return Page();
            }

            var job = await _jobPositionAppService.UpdateAsync(form.Id, form);
            if (job != null)
            {
                return RedirectToPage("Detail", new { id = job.Id });
            }
            else
            {
                Form = form;
                //ViewData["Exception"] = update.Exception.ToString();
                return Page();
            }
        }
    }
}
