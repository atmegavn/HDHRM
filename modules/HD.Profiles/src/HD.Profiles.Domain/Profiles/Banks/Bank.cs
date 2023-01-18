using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Profiles.Banks
{
    public class Bank: Entity<Guid>
    {
        public string Name { get;set; }
        public string Decsiption { get; set; }
        public string Icon { get; set; }
        public byte[] Logo { get; set; }

    }
}
