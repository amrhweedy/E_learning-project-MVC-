using E_Learning_Platform.Models;

namespace E_Learning_Platform.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Course? Course { get; set; }
    }
}
