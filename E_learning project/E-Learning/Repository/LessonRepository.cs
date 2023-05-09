using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using E_Learning.ViewModels;
using E_Learning.Interface;
using E_Learning.viewmodel;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repository
{
    public class LessonRepository: GenericRepository<Lesson>, ILessonRepository
    {
        E_LearningContext context;
        public LessonRepository(E_LearningContext _context) : base(_context)
        {
            context = _context;
        }

        public LessonViewModel GetById([FromRoute] int id)
        {
            var lesson= context.Lessons.Include(c=>c.Course).FirstOrDefault(l => l.Id == id);
            LessonViewModel LessonVM = new LessonViewModel();
            LessonVM.Title = lesson.Lesson_Title;
            LessonVM.Content = lesson.Lesson_Content;
            LessonVM.Duration = lesson.Lesson_Duration;

            return LessonVM;
        }
    }
}
