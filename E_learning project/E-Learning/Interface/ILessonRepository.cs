using E_Learning.viewmodel;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace E_Learning.Interface
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        public LessonViewModel GetById([FromRoute] int id);
    }
}
