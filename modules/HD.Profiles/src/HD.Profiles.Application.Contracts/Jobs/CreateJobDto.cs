using System;
using System.Collections.Generic;
using System.Text;

namespace HD.Profiles.Jobs
{
    public class CreateJobDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public Guid JobFamilyId { get; set; }
    }
}
