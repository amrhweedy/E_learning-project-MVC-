using E_Learning.Interface;
using E_Learning.viewmodel;
using E_Learning_Platform.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace E_Learning.Repository
{
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        E_LearningContext context;
        public FeedbackRepository(E_LearningContext _context) : base(_context)
        {
            context = _context;
        }

        public List<FeedbackViewModel> GetAllByCrsId(int id)
        {
            var feedbacks = context.Feedbacks.Include(f=>f.Student).ThenInclude(s=>s.App_User).Where(f => f.CourseId == id).ToList();
            List<FeedbackViewModel> FeedbackVM = new List<FeedbackViewModel>();
            foreach (var feedback in feedbacks)
            {
                FeedbackVM.Add(new FeedbackViewModel
                {
                    Id = feedback.Id,
                    Date = feedback.Date,
                    Comment = feedback.Comment,
                    Student = feedback.Student,
                    Rating = feedback.Rating,
                });
            }
            return FeedbackVM;
        }
        public void Insert(Feedback feedback)
        {
            if (feedback.Comment != null)
            {
                feedback.Date = DateTime.Now;
                feedback.Rating = 3;
                context.Add(feedback);
                context.SaveChanges();
            }
            
        }
    }
}

