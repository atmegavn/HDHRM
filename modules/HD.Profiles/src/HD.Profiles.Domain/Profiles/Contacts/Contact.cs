using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Contacts
{
    public class Contact : Entity<Guid>
    {
        public string Name { get; set; }
        public string Content { get; set; } //phone number, email, social link...
        public Guid ContactProviderId { get; set; }
        public ContactProvider ContactProvider { get; set; } //viettel, zalo, facebook, linkin...
        public ContactType Type { get; set; } //telephone, email, socialnetwork...
        public Guid? ProfileId { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
