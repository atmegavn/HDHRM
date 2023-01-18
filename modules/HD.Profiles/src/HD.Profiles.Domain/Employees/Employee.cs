using HD.Profiles.Jobs;
using HD.Profiles.Organizations;
using HD.Profiles.Profiles.Relatives;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.Profiles.Employees
{
    public class Employee: FullAuditedAggregateRoot<Guid>
    {
        public byte[] Avatar { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfOnboard { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Guid? ProfileId { get; set; }
        public Guid? JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }
        public Guid? OrganzinationId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? StatusId { get; set; }
        public Status Status { get; set; } //trạng thái nhân viên: thử việc, chính thức, nghỉ việc, nghỉ không lương...
        public virtual ICollection<JobPosition> Positions { get; set; }
        public virtual ICollection<Relative> Relatives { get; set; }

    }
}
