using System;
using System.Collections.Generic;

namespace Server.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } 
        public DateTime LastActive { get; set; } 

        public string Email { get; set; }
        public int Age { get; set; }

        public string Gender { get; set; }

        public ICollection<LessonDto> Lessons { get; set; }
    }
}
