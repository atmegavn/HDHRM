using HD.Profiles.Contacts;
using HD.Profiles.Profiles;
using HD.Profiles.Profiles.Banks;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.Profiles.Organizations
{
    public class Organization: FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; } // mã dơn vị
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? ParentId { get; set; }
        public Organization Parent { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Level Level { get; set; }

        public virtual ICollection<JobPosition> Positions { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Account> BankAccounts { get; set; }
    }
}
