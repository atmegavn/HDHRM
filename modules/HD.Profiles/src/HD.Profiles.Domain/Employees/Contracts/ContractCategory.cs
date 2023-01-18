using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Employees.Contracts
{
    public class ContractCategory : Entity<Guid>
    {
        public string Name { get; set; } //hđ thử việc, hđ chính thức 1 năm, 3 năm, không xác định thời hạn
        public string Description { get; set; }
    }
}
