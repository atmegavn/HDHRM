using System;
using System.Collections.Generic;
using System.Text;

namespace HD.Profiles.Organizations
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public Guid JobPositionId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
