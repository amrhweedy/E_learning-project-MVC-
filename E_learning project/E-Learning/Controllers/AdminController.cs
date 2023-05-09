using E_Learning.Interface;
using E_Learning.viewmodel;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class AdminController : Controller
    {
        IGenericRepository<Course> courseRepo;
        IStudentRepository studentRepo;


        public AdminController(IGenericRepository<Course> courseRepo, IStudentRepository studentRepo)
        {
            this.courseRepo = courseRepo;
            this.studentRepo = studentRepo;

        }
        public IActionResult Show_add_course()
        {

            return View();
        }
        public IActionResult add_course(Course newCourse)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Insert(newCourse);
                return RedirectToAction("Index", "Home");
            }


            return View("Show_add_course", newCourse);
        }
        [HttpGet]
        public IActionResult showEditCourse(int id)
        {
            Course existCourse = courseRepo.GetById(id);
            return View(existCourse);
        }
        [HttpPost]
        public IActionResult Edit_Course(Course Edited_course)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Update(Edited_course);
                return RedirectToAction("Index", "Home");
            }
            return View("showEditCourse", Edit_Course);
        }

        public IActionResult allRegisterdStudent()
        {
            List<UserStudentViewModel> allStudent = studentRepo.GetAllIncludeUserData();
            return View(allStudent);
        }

    }
}
