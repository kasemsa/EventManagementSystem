﻿using EventManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Domain.Entities
{
    public class User:BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; }= string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Roll { get; set; } = string.Empty;

        public ICollection<Event> events { get; set; } = default!;


    }
}
