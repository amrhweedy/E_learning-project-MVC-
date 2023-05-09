using E_Learning.Interface;
using E_Learning.Repository;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [Authorize]
    public class LessonController : Controller
    {
        ILessonRepository lessonRepository;
        public LessonController(IGenericRepository<Course> courseRepo,
            ILessonRepository _lessonRepository)
        {
            lessonRepository = _lessonRepository;

        }
        public IActionResult ShowLesson([FromRoute] int id)
        {
            var lesson = lessonRepository.GetById(id);
            return View(lesson);
        }
    }
}
