namespace Server.Entities
{
    public class UserLesson
    {
        public Lesson Lesson { get; set; }
        public int LessonId { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
