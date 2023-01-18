using HD.Profiles.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;

namespace HD.Profiles.Web.Pages.Employees
{
    public class DetailModel : PageModel
    {
        public readonly IEmployeeAppService _employeeAppService;
        public EmployeeDto Employee { get; set; }
        public string BackUrl { get; set; }

        public DetailModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }
        public async Task OnGetAsync(Guid id, string backUrl)
        {
            Employee = await _employeeAppService.GetAsync(id);
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
        }
    }
}
