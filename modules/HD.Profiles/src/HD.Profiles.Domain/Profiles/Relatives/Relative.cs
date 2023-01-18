using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Profiles.Relatives
{
    public class Relative: Entity<Guid>
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public Guid? ProfileId { get; set; }
        public Guid RelationshipId { get; set; }
        public Relationship Relationship { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
