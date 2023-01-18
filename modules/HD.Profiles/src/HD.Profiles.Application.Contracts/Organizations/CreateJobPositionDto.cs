using HD.Profiles.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.Profiles.Organizations
{
    public interface CreateJobPositionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public JobLevel JobLevel { get; set; }
        public Guid JobFamilyId { get; set; }
    }
}
