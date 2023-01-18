using HD.Profiles.JobTitles;
using HD.Profiles.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace HD.Profiles.Web.Pages.JobTitles
{
    public class CreateModel : ProfilesPageModel
    {
        public CreateJobTitleDto Form { get; set; }
        public string BackUrl { get; set; }
        public readonly IJobTitleAppService _jobTitleAppService;

        public CreateModel(IJobTitleAppService jobTitleAppService)
        {
            _jobTitleAppService = jobTitleAppService;
        }
        public async Task OnGetAsync(string backUrl)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
            Form = new CreateJobTitleDto();
        }

        public async Task<ActionResult> OnPostAsync(CreateJobTitleDto form)
        {
            if (!ModelState.IsValid)
            {
                Form = form;
                ViewData["Exception"] = "Form Invalid";
                return Page();
            }

            var insert = _jobTitleAppService.CreateAsync(form);
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
