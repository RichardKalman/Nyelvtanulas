using System.Collections.Generic;

namespace Server.Entities
{
    public class LessonResult
    {
        public int Id { get; set; }
        public int CorrectWord { get; set; }
        public int NotCorrectWord { get; set; }

        public ICollection<UserLessonResult> Users { get; set; }

        public ICollection<LessonLessonResult> Lessons { get; set; }
        
    }
}
