using System.Collections.Generic;

namespace Server.Entities
{
    public class Word
    {
        public int Id { get; set; }
        public string EnglishWord { get; set; }

        public string HungaryWord { get; set; }
        
        public ICollection<Lesson> Lessons { get; set; }
    }
}
