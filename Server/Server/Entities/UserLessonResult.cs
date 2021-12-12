namespace Server.Entities
{
    public class UserLessonResult
    {
        public LessonResult LessonResult { get; set; }
        public int LessonResultId { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
