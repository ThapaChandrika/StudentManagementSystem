﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime DateCreated { get; set; }
    }
}
