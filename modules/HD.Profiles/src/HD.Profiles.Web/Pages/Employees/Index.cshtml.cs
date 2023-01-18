using HD.Profiles.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Domain.Repositories;

namespace HD.Profiles.Web.Pages.Employees
{
    public class IndexModel : ProfilesPageModel
    {
        private readonly IEmployeeAppService _employeeAppService;
        public PagedResultDto<EmployeeDto> Result { get; set; }
        public PagedAndSortedResultRequestDto Params = new PagedAndSortedResultRequestDto();
        public IndexModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public async Task OnGetAsync(PagedAndSortedResultRequestDto input)
        {
            Params = input;
            Result = await _employeeAppService.GetListAsync(input);
        }
    }
}
