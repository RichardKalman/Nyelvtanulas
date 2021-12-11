﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        
        public string Email { get; set; }

        public string Gender { get; set; }

        public ICollection<UserLesson> Lessons { get; set; }

    }
}
