

using System.Collections.Generic;

namespace Server.DTOs
{
    public class LessonResultRequestDto
    {
        public int userId { get; set; }
        public int lessonId { get; set; }

        public ICollection<WordDto> words {get; set;}
    }
}
