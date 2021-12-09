namespace Server.Entities
{
    public class LessonWord
    {
        public Lesson Lesson { get; set; }
        public int LessonId { get; set; }  
        public Word Word { get; set; }
        public int WordId { get; set; }
    }
}
