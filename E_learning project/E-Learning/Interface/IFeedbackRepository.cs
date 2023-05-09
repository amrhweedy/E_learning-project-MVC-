using E_Learning.viewmodel;
using E_Learning_Platform.Models;

namespace E_Learning.Interface
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        public List<FeedbackViewModel> GetAllByCrsId(int id);
        public void Insert(Feedback feedback);
    }
}
