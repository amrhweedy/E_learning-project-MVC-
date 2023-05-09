namespace E_Learning_Platform.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Course? Course { get; set; }
    }
}
