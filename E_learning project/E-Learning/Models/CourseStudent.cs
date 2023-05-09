using E_Learning_Platform.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Models
{
    public class CourseStudent
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        [DefaultValue(false)]
        public bool IsPaid { get; set; }
        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }

    }
}
