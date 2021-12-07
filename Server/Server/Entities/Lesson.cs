using System.Collections.Generic;

namespace Server.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Word> Words { get; set; }
    }
}
