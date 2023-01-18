using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Locations
{
    public class Street : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid VillageId { get; set; }
        public Village Village { get; set; }

    }
}
