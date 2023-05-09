using E_Learning.Interface;
using E_Learning_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repository
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        E_LearningContext context;
        public EnrollmentRepository(E_LearningContext _context) : base(_context)
        {
            context = _context;
        }
        public bool IsEnrolled(int studentId, int courseId)
        {
            return context.Enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId);
        }

    }
}
