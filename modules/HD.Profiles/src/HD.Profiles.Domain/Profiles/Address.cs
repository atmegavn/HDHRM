using HD.Profiles.Locations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Profiles
{
    public class Address : Entity<Guid>
    {
        public string Name { get; set; }
        public Guid LocationId { get; set; }
        public Guid? ProfileId { get; set; }
        public Guid? OrganizationId { get; set; }
        public Boolean IsMain { get; set; }
        public Location Location { get; set; }
    }
}
