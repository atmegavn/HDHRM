using HD.Profiles.JobTitles;
using HD.Profiles.Organizations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.Profiles.Employees
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfOnboard { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Guid ProfileId { get; set; }
        public Guid JobTitleId { get; set; }
        public JobTitleDto JobTitle { get; set; }
        public List<JobPositionDto> Positions { get; set; }
    }
}
