using System.Collections.Generic;

namespace Server.DTOs
{
    public class UpdateLessonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public List<int> WordIds { get; set; } = new List<int>();
    }
}
