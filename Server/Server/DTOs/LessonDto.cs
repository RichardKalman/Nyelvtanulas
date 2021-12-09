using System.Collections.Generic;

namespace Server.DTOs
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public IEnumerable<WordDto> Words { get; set; }
    }
}
