namespace Server.Entities
{
    public class LessonLessonResult
    {
        public LessonResult LessonResult { get; set; }
        public int LessonResultId { get; set; }
        public Lesson Lesson { get; set; }

        public int LessonId { get; set; }
    }
}
