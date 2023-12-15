using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace HD.Profiles.Web.Pages.Organizations
{
    public class PositionCreateModel : PageModel
    {
        public string BackUrl { get; set; }
        public async Task OnGetAsync(Guid id, string backUrl)
        {
            BackUrl= backUrl;
        }
    }
}
