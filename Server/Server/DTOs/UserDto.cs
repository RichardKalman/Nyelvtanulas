using System.Collections.Generic;

namespace Server.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public IEnumerable<LessonDto> Lessons { get; set; }
    }
}