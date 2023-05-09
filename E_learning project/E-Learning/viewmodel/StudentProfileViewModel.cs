using E_Learning.Models;
using E_Learning_Platform.Models;

namespace E_Learning.viewmodel
{
    public class StudentProfileViewModel
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public string Profile_picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CrsEnrolled { get; set; }
        public App_user User { get; set; }
        public List<Course>? Enrolled_Courses { get; set; }
    }
}
