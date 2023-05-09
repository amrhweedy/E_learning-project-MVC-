namespace E_Learning.Interface
{
    public interface IEnrollmentRepository
    {
        public bool IsEnrolled(int studentId, int courseId);
    }
}
