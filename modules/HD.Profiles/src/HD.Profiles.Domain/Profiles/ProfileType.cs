﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.Profiles.Profiles
{
    public class ProfileType : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
