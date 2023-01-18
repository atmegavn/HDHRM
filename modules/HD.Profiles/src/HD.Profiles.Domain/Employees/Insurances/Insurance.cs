using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Employees.Insurances
{
    public class Insurance: Entity<Guid>
    {
        public string NumberOfInsurance { get; set; }
    }
}
