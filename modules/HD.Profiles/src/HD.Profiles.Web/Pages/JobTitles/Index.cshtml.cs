using HD.Profiles.JobTitles;
using HD.Profiles.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HD.Profiles.Web.Pages.JobTitles
{
    public class IndexModel : PageModel
    {
        public readonly IJobTitleAppService _jobTitleAppService;
        public PagedResultDto<JobTitleDto> Result { get; set; }
        public PagedAndSortedResultRequestDto Request = new PagedAndSortedResultRequestDto();
        public IndexModel(IJobTitleAppService jobTitleAppService)
        {
            _jobTitleAppService = jobTitleAppService;
        }
        public async Task OnGetAsync(PagedAndSortedResultRequestDto request)
        {
            Request = request;
            Result = await _jobTitleAppService.GetListAsync(request);
        }
    }
}
