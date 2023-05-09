using E_Learning.Interface;
using E_Learning.Repository;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using E_Learning.Models;
using E_Learning.viewmodel;

namespace E_Learning.Controllers
{

    public class StudentController : Controller
    {
        IStudentRepository studentRepository;
        public StudentController(IGenericRepository<Course> courseRepo,
            IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        public IActionResult Profile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            List<Claim> claims = User.Claims.ToList();
            Claim? ClaimID = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = ClaimID.Value;

            var student=studentRepository.GetCrsByStudentId(userId);
            return View(student);
        }
        [HttpGet]
        public IActionResult EditPartial()
        {
            List<Claim> claims = User.Claims.ToList();
            Claim? ClaimID = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = ClaimID.Value;

            var studentmodel = studentRepository.GetCrsByStudentId(userId);
            var student = studentRepository.GetById(studentmodel.Id);
            var StudentModel = new StudentProfileViewModel()
            {
                Id = student.Id,
                Bio = student.Bio,
                Profile_picture = student.Profile_Picture
            };

            return PartialView(StudentModel);
        }
        [HttpPost]
        public IActionResult EditPartial([FromRoute] int id, Student student)
        {
            var StudentModel = new StudentProfileViewModel()
            {
                Id = student.Id,
                Bio = student.Bio,
                Profile_picture = student.Profile_Picture
            };
            if (student.Bio != null)
            {
                studentRepository.UpdateStudent(id, student);
                return RedirectToAction("Profile");
            }

            return PartialView(StudentModel);
        }
    }
}
