using System;

namespace Server.DTOs
{
    public class MemberUpdateDto
    {
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
