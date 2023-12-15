using HD.Profiles.Decisions;
using HD.Profiles.Employees;
using HD.Profiles.Jobs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Organizations
{
    public class JobPosition: Entity<Guid>
    {
        public string Name { get; set; }
        //public string JobDescription { get; set; }
        //public string JobRequirement { get; set; }
        public Guid? DecisionId { get; set; }
        public Decision Decision { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        //public DateTimeOffset? ApplyDate { get; set; }

    }
}
