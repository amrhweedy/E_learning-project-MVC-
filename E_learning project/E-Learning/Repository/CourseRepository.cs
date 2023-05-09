using E_Learning.Interface;
using E_Learning.viewmodel;
using E_Learning.ViewModels;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace E_Learning.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        E_LearningContext context;
        public CourseRepository(E_LearningContext _context) : base(_context)
        {
            context = _context;
        }

        public bool AddEnrollment(Enrollment enrollment)
        {
            context.Enrollments.Add(enrollment);
            var result = context.SaveChanges();
            return result > 0;
        }
        public async void AddEnrollment(EnrollmentViewModel enrollmentViewModel)
        {
            var enrollment = new Enrollment
            {
                StudentId = enrollmentViewModel.StudentId,
                CourseId = enrollmentViewModel.CourseId,
                Date = DateTime.Now
            };

            context.Enrollments.Add(enrollment);
            context.SaveChanges();
        }

        public List<CourseViewModel> GetAll()
        {
            var courses = context.Courses.ToList();
            List<CourseViewModel> CrsVM = new List<CourseViewModel>();
            foreach (var course in courses)
            {
                CrsVM.Add(new CourseViewModel
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    Price = course.Price,
                    Category = course.Category,
                    Rating = course.Rating,
                    certificate_Date = DateTime.Now,
                    certificate_Title = course.certificate_Title,
                    Duration = course.Duration,
                    Image = course.Image,
                    Lessons = course.Lessons,
                    Feedbacks = course.Feedbacks
                });
            }
            return CrsVM;
        }
        public CourseViewModel GetById([FromRoute] int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            var Lessons = context.Lessons.Where(l => l.CourseId == id).ToList();
            var Feedbacks = context.Feedbacks.Where(f => f.CourseId == id).ToList();

            CourseViewModel courseViewModel = new CourseViewModel();
            courseViewModel.Id = course.Id;
            courseViewModel.Name = course.Name;
            courseViewModel.Description = course.Description;
            courseViewModel.Category = course.Category;
            courseViewModel.Price = course.Price;
            courseViewModel.Rating = course.Rating;
            courseViewModel.certificate_Date = DateTime.Now;
            courseViewModel.certificate_Title = course.certificate_Title;
            courseViewModel.Duration = course.Duration;
            courseViewModel.Image = course.Image;
            courseViewModel.Lessons = Lessons;
            courseViewModel.Feedbacks = Feedbacks;

            return courseViewModel;
        }

    }
}
