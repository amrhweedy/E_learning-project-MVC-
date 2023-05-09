using E_Learning_Platform.Models;

namespace E_Learning_Platform.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Lesson_Title { get; set; }
        public string Lesson_Content { get; set; }
        public int Lesson_Duration { get; set; }
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }
    }
}
