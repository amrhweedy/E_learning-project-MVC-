using E_Learning.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Platform.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        public string? Bio { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        public string? Profile_Picture { get; set; }
        [ForeignKey("App_User")]
        public string User_id { get; set; }
        public virtual App_user? App_User { get; set; }
        
        public virtual List<Payment>? Payments { get; set; }
        public virtual List<Enrollment>? Enrollments { get; set; }

    }
}
