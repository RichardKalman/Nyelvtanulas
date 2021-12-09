using System.Collections.Generic;

namespace Server.DTOs
{
    public class AddLessonDto
    {
        public string Name { get; set; }
        public string Level { get; set; }

        public List<int> WordIds { get; set; } = new List<int>();

        //public List<WordDto> Words { get; set; }
    }
}
