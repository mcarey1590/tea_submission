namespace student_api.Repositories
{
    public interface ICoursesRepository
    {
        bool Exists(int courseId);
    }
}
