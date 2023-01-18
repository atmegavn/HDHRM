using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Profiles.Banks
{
    public class Account: Entity<Guid>
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public Guid BankId { get; set; }
        public Bank Bank { get; set; }
        public Guid? ProfileId { get; set; }
        public Guid? OrganizationId { get; set; }
        public bool IsPrimary { get; set; }
    }
}
