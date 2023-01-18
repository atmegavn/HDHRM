using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Employees.Contracts
{
    public class Contract : Entity<Guid>
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public ContractCategory Category { get; set; }
        public int Period { get; set; } //thoi han hd
        public PeriodUnit PeriodUnit { get; set; }//don vi cua thoi han hd: ngay, thang, nam
        public string OrganizationName { get; set; }
        public string OrganizationAddress { get; set; }
        public string PartyA { get; set; }
        public string PartyAAddress { get; set; }
        public string PartyB { get; set; }
        public string PartyBAddress { get; set; }
        public DateTimeOffset PartyBBirdDay { get; set; }
        public string JobTitle { get; set; }
        public string JobPosition { get; set; }
        public long Salary { get; set; }

    }
}
