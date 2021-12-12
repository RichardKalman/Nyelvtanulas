using System.Collections.Generic;

namespace Server.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Level { get; set; }

        public ICollection<LessonWord> Words { get; set; }
        public ICollection<UserLesson> Users { get; set; }

        public ICollection<LessonLessonResult> LessonResults { get; set; }
    }
}
