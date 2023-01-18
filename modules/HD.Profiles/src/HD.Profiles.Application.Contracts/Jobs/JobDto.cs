using System;
using System.Collections.Generic;
using System.Text;

namespace HD.Profiles.Jobs
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public int PositionClass { get; set; }
        public JobFamilyDto JobFamily { get; set; }
        public JobLevel Level { get; set; }
    }
}
