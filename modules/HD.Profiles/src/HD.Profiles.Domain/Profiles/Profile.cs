using HD.Profiles.Contacts;
using HD.Profiles.Profiles.Banks;
using HD.Profiles.Profiles.Relatives;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Profiles
{
    public class Profile: Entity<Guid>
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string GivenName { get; set; }

        //public string About { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset DateOfBird { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string TaxCode { get; set; }
        public Guid ProfileTypeId { get; set; }
        public ProfileType ProfileType { get; set; }

        public virtual ICollection<IdCard> Cards { get; set; }
        public virtual ICollection<Address> Address { get; private set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Account> BankAccounts { get; set; }
    }
}
