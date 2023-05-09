using E_Learning.Models;
using E_Learning.ViewModels;

namespace E_Learning.Interface
{
    public interface ICourseStudentRepository
    {
        public void Delete(int courseId,int studentId);
        public void Insert(CourseStudent crsStudent);
        public List<StudentCourseViewModel> GetByStudentId(int studentId);
        public void UpdateIsPaid(int stdId);
        public bool IsPaid(int studentId, int courseId);
    }
}
