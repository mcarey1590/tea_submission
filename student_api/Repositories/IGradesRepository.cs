using System.Collections.Generic;
using System.Threading.Tasks;
using student_api.Models;
using student_api.ViewModels;

namespace student_api.Repositories
{
    public interface IGradesRepository
    {
        Task<IEnumerable<StudentCourseGrade>> GetByStudentId(int studentId);
        StudentGrade AddGrade(StudentGrade studentGrade);
    }
}
