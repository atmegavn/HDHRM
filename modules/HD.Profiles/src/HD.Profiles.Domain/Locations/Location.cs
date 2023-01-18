using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Locations
{
    public class Location : Entity<Guid>
    {
        public string Address { get; set; }//so 14 ngo 18
        public Guid StreetId { get; set; }
        public Street Street { get; set; } //vo van dung
        public Guid VillageId { get; set; }
        public Village Village { get; set; } // o cho dua
        public Guid DistrictId { get; set; }
        public District District { get; set; }//quan dong da
        public Guid ProvincialId { get; set; }
        public Provincial Provincial { get; set; }//tp ha noi
        public Guid NationalId { get; set; }
        public National National { get; set; }//Viet nam
        public Guid ProfileId { get; set; }
    }
}
