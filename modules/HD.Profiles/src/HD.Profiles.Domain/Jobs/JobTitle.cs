using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Jobs
{
    public class JobTitle: Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
