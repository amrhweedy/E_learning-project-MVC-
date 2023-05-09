using E_Learning.viewmodel;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Interface
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        public List<CourseViewModel> GetAll();
        public CourseViewModel GetById([FromRoute] int id);
        public  bool AddEnrollment(Enrollment enrollment);
        public  void AddEnrollment(EnrollmentViewModel enrollmentViewModel);
       
    }
}
