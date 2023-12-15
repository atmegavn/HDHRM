using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HD.Profiles.Organizations
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }    
        public string Location { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }    
        public string Phone { get; set; }    
        public string Email { get; set; }
        public Guid? ParentId { get; set; }
        public Level Level { get; set; }

        public List<JobPositionDto> Positions { get; set; }
        public List<OrganizationDto> Childrent { get; set; }
    }
}
