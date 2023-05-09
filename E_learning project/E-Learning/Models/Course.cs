using E_Learning_Platform.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Platform.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Duration { get; set; }
        public float Rating { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        [ForeignKey("Payment")]
        public int? PaymentId { get; set; }
        public string? certificate_Title { get; set; }
        public DateTime? certificate_Date { get; set; }
        public virtual List<Lesson>? Lessons { get; set; }
        public virtual List<Feedback>? Feedbacks { get; set; }
        public virtual List<Enrollment>? Enrollments { get; set; }

    }
}
