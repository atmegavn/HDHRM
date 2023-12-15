using HD.Profiles.Employees;
using HD.Profiles.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.Profiles.Organizations
{
    public class JobPositionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid? DecisionId { get; set; }
        public Guid JobId { get; set; }
        public Guid OrganizationId { get; set; }
        public OrganizationDto Organization { get; set; }
        public JobDto Job { get; set; }
    }
}
