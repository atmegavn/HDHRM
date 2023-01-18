using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Locations
{
    public class Provincial : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid NationalId { get; set; }
        public National National { get; set; }
    }
}
