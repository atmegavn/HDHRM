using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.Profiles.Employees
{
    public class CreateEmployeeDto
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset DateOfOnboard { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }

        [Required]
        public Guid JobTitleId { get; set; }
        public string BackUrl { get; set; }
       
    }
}
