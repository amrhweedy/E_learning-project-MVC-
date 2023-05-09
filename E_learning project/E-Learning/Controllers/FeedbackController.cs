using E_Learning.Interface;
using E_Learning.Repository;
using E_Learning.viewmodel;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class FeedbackController : Controller
    {
        IFeedbackRepository FeedbackRepository;
        public FeedbackController(IGenericRepository<Feedback> feedbackRepo,
            IFeedbackRepository _feedbackRepository)
        {
            FeedbackRepository = _feedbackRepository;
        }
        public IActionResult Index([FromRoute] int id)
        {
            var feedbacks=FeedbackRepository.GetAllByCrsId(id);
            return View(feedbacks);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Add(Feedback feedback)
        {
            feedback.Student.App_User.UserName = User.Identity.Name;
            if (ModelState.IsValid == true)
            {
                try
                {
                    FeedbackRepository.Insert(feedback);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }

            return PartialView(feedback);
        }
    }
}
