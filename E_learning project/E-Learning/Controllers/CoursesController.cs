using E_Learning.Interface;
using E_Learning.Repository;
using E_Learning.viewmodel;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class CoursesController : Controller
    {
        ICourseRepository courseRepository;
        IFeedbackRepository feedbackRepository;
        IStudentRepository studentRepository;
        IEnrollmentRepository EnrollmentRepository;
        public CoursesController(IEnrollmentRepository EnrollmentRepo,
            ICourseRepository _courseRepository,
            IFeedbackRepository _feedbackRepository,
            IStudentRepository _studentRepository)
        {
            courseRepository = _courseRepository;
            feedbackRepository = _feedbackRepository;
           studentRepository = _studentRepository;
            EnrollmentRepository = EnrollmentRepo;
        }
        public IActionResult Index()
        {
            var Courses = courseRepository.GetAll();
            return View(Courses);
        }
        public IActionResult CourseDetails(int id)
        {
            var Course = courseRepository.GetById(id);
            return View(Course);
        }
        [HttpGet]
        public IActionResult AddFeedback(int courseId)
        {
            var feedbackViewModel = new FeedbackViewModel { CourseId = courseId };
            return View("CourseDetails", feedbackViewModel);
        }
        [HttpPost]
        public IActionResult AddFeedback(FeedbackViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student = studentRepository.GetCrsByStudentId(userId);

            var feedback = new Feedback();
            feedback.CourseId = model.CourseId;
            feedback.StudentId = student.Id;
            feedback.Comment = model.Comment;
            feedback.Rating = model.Rating;
            feedback.Date = DateTime.Now;

            if ( ModelState.IsValid==true) 
            {
                feedbackRepository.Insert(feedback);
                return RedirectToAction("Index", "Courses");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Enroll(int courseId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student = studentRepository.GetCrsByStudentId(userId);
            bool isEnrolled = EnrollmentRepository.IsEnrolled(student.Id, courseId);

            if (isEnrolled)
            {
                TempData["ErrorMessage"] = "You have already enrolled in this course";
                return RedirectToAction("Profile", "Student");
            }

            var enrollment = new Enrollment
            {
                StudentId = student.Id,
                CourseId = courseId,
                Date = DateTime.Now
            };

            courseRepository.AddEnrollment(enrollment);
            TempData["SuccessMessage"] = "You have successfully enrolled in the course";
            return RedirectToAction("Profile", "Student");
        }

    }
}
