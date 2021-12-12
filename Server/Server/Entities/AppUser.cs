using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Fullname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;        

        public string Gender { get; set; }

        public ICollection<UserLesson> Lessons { get; set; }

        public ICollection<UserLessonResult> LessonResults { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }

    }
}
