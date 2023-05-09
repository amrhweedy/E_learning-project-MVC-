using E_Learning.Models;
using E_Learning.viewmodel;
using E_Learning_Platform.Models;

namespace E_Learning.Interface
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        Student GetByUserId(string id);
        public StudentProfileViewModel GetCrsByStudentId(string userId);
        public void UpdateStudent(int id, Student student);
        public List<UserStudentViewModel> GetAllIncludeUserData();
    }
}
