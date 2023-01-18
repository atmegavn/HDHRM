using HD.Profiles.Employees;
using HD.Profiles.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Profiles.Web.Pages.Organizations
{
    public class AppointModel : PageModel
    {
        public AppointmentDto Form { get; set; }
        public List<SelectListItem> Employees { get; set; }
        public readonly IOrganizationAppService _organizationAppService;    
        public readonly IEmployeeAppService _employeeAppService;    

        public AppointModel(IOrganizationAppService organizationAppService, IEmployeeAppService employeeAppService)
        {
            _organizationAppService = organizationAppService;
            _employeeAppService = employeeAppService;
        }
        public async Task OnGetAsync(Guid id)
        {
            var form = new AppointmentDto();
            var employeeLookUp = await _employeeAppService.GetEmployeeLookupAsync(new List<Guid>()); ;
            Employees = employeeLookUp.Items.Select(p => new SelectListItem(p.Name, p.Id.ToString())).ToList();
            var position = await _organizationAppService.GetOrganizationPositionAsync(id);
            form.Id = id;
            form.Name = position.Name;
            form.OrganizationId = position.OrganizationId;
            //form.OrganizationName = position.Organization.Name;
            form.JobPositionId = position.JobId;
            form.StartDate = DateTime.Now;
            form.EndDate = form.StartDate.AddYears(1);
            Form = form;
        }

        public async Task<ActionResult> OnPostAsync(AppointmentDto form)
        {
            if (!ModelState.IsValid)
            {
                Form = form;
                ViewData["Exception"] = "Form Invalid";
                return Page();
            }

            await _organizationAppService.UpdatePositionAsync(form);
            var result = new JsonResult(new { Result = "OK", Message = "" });
            return result;
        }
    }
}
