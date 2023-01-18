using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Jobs
{
    public class JobFamily: Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }
        public JobFamily Parent { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<JobFamily> Childs { get; set; }
    }
}
