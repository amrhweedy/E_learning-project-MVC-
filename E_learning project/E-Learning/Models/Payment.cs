using E_Learning_Platform.Models;

namespace E_Learning_Platform.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public DateTime Date { get; set; }
        public string? SessionId { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }
        public int StudentId { get; set; }
        public virtual List<Course>? Courses { get; set; }
        public virtual Student? Student { get; set; }

    }
}
