using System;
using System.Collections.Generic;
using System.Text;

namespace HD.Profiles.Jobs
{
    public class EditJobDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public Guid JobFamilyId { get; set; }
        public JobLevel Level { get; set; }
    }
}
