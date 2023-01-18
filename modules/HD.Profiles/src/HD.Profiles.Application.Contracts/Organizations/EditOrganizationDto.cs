using HD.Profiles.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HD.Profiles.Organizations
{
    public class EditOrganizationDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid ParentId { get; set; }
        public Level Level { get; set; }
        //public List<OrganizationPositionDto> Positions { get; set; }
    }
}
