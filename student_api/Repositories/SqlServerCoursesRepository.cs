using System.Linq;
using student_api.Models;

namespace student_api.Repositories
{
    public class SqlServerCoursesRepository : ICoursesRepository
    {
        private readonly SchoolContext _context;

        public SqlServerCoursesRepository(SchoolContext context)
        {
            _context = context;
        }

        public bool Exists(int courseId)
        {
            return _context.Courses.Any(c => c.CourseID == courseId);
        }
    }
}
