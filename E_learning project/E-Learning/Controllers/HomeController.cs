using E_Learning.Interface;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class HomeController : Controller
    {
        ICourseRepository courseRepository;
        IFeedbackRepository feedbackRepository;
        public HomeController(IGenericRepository<Course> courseRepo,
            ICourseRepository _courseRepository,
            IFeedbackRepository _feedbackRepository)
        {
            courseRepository = _courseRepository;
            feedbackRepository = _feedbackRepository;
        }
        public IActionResult Index()
        {
            var Courses = courseRepository.GetAll();
            return View(Courses);
        }
    }
}
