using HD.Profiles.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD.Profiles.Web.Pages.Organizations
{
    public class EditModel : ProfilesPageModel
    {
        public OrganizationDto Form { get; set; }
        public string BackUrl { get; set; }
        private readonly IOrganizationAppService _organizationAppService;
        public EditModel(IOrganizationAppService organizationAppService)
        {
            _organizationAppService = organizationAppService;
        }
        public async Task OnGetAsync(Guid id, string backUrl)
        {
            Form = await _organizationAppService.GetAsync(id);

            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
        }

        public async Task<ActionResult> OnPostAsync(OrganizationDto form)
        {
            if (!ModelState.IsValid)
            {
                Form = form;
                ViewData["Exception"] = "Form Invalid";
                return Page();
            }

            var org = await _organizationAppService.UpdateAsync(form.Id, form);
            if (org != null)
            {
                return RedirectToPage("Detail", new { id = org.Id });
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
