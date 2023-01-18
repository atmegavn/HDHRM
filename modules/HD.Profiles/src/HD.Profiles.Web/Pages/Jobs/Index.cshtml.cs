using HD.Profiles.Jobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HD.Profiles.Web.Pages.Jobs
{
    public class IndexModel : ProfilesPageModel
    {
        private readonly IJobAppService _jobPositionAppService;
        public PagedResultDto<JobDto> Result { get; set; }
        public PagedAndSortedResultRequestDto Params = new PagedAndSortedResultRequestDto();
        public IndexModel(IJobAppService jobPositionAppService)
        {
            _jobPositionAppService = jobPositionAppService;
        }
        public async Task OnGetAsync(PagedAndSortedResultRequestDto input)
        {
            Params = input;
            Result = await _jobPositionAppService.GetListAsync(input);
        }
    }
}
