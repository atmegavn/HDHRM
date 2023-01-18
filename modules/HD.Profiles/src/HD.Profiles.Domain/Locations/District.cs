using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Locations
{
    public class District : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProvincialId { get; set; }
        public Provincial Provincial { get; set; }
    }
}
