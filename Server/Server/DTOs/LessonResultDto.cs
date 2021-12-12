using System.Collections.Generic;

namespace Server.DTOs
{
    public class LessonResultDto
    {
        public int Id { get; set; }
        public int CorrectWord { get; set; }
        public int NotCorrectWord { get; set; }
        public string LessonName { get; set; }

        //public List<MemberDto> Users { get; set; }

        //public List<LessonDto> Lessons { get; set; }
    }
}
