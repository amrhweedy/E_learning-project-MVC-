using E_Learning.Interface;
using E_Learning.Models;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class CartController : Controller
    {
        IStudentRepository studentRepository;
        ICourseStudentRepository courseStudentRepository; 
        public CartController(IGenericRepository<Course> courseRepo,
            IStudentRepository studentRepo, ICourseStudentRepository courseStudentRepo)
        {
            studentRepository= studentRepo;
            courseStudentRepository= courseStudentRepo;
        }
        public IActionResult Index()
        {
            Claim claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            int stdId = studentRepository.GetByUserId(claim.Value).Id;
            var studentCourses = courseStudentRepository.GetByStudentId(stdId);
            return View("Index2",studentCourses);
        }
        public IActionResult Add(int courseId)
        {

            Claim claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            int stdId = studentRepository.GetByUserId(claim.Value).Id;
            CourseStudent crsStd = new CourseStudent();
            crsStd.StudentId = stdId;
            crsStd.CourseId = courseId;

            var isPaid = courseStudentRepository.IsPaid(stdId, courseId);
            if (isPaid)
            {
                TempData["ErrorMessage"] = "You have already enrolled in this course";
                return RedirectToAction("Profile", "Student");
            }
            courseStudentRepository.Insert(crsStd);
            return RedirectToAction("Index");  
        }
        public IActionResult Delete(int courseId)
        {

            Claim claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            int stdId = studentRepository.GetByUserId(claim.Value).Id;
            courseStudentRepository.Delete(courseId, stdId);
            return RedirectToAction("Index");
        }
    }
}
