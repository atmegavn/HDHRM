using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Contacts
{
    public class ContactProvider: Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Icon { get; set; }
        public byte[] Logo { get; set; }
    }
}
