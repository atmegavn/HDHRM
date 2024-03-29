﻿using HD.Profiles.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.Profiles.Organizations
{
    public class AddPositionDto
    {
        [Required]
        [Range(1, 999)]
        public int Amount { get; set; } = 1;

        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public string JobRequirement { get; set; }
        [Required]
        public Guid OrganizationId { get; set; }
        public Guid JobPositionId { get; set; }
        public string BackUrl { get; set; }
    }
}
