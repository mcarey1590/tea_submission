using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using student_api.Models;
using student_api.Util;
using student_api.ViewModels;

namespace student_api.Repositories
{
    public class SqlServerStudentsRepository : IStudentsRepository
    {
        const string STUDENT_DISCRIMINATOR = "Student";
        private readonly SchoolContext _context;
        private readonly IGradesRepository _gradesRepo;

        public SqlServerStudentsRepository(SchoolContext context, IGradesRepository gradesRepo)
        {
            _context = context;
            _gradesRepo = gradesRepo;
        }

        public async Task<Transcript> GetTranscript(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return null;
            }

            if (person.Discriminator != STUDENT_DISCRIMINATOR)
            {
                return null; // Returning null instead of throwing an error because the end user specifically requested a student and a student does not exist with that ID
            }

            return await CreateStudentTranscript(person);

        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.FromSqlRaw(@"
                SELECT
                    PersonID as StudentId
                    , FirstName
                    , LastName
                    , ROUND(SUM(grade.Grade * course.Credits) / SUM(course.Credits),2) as Gpa
                FROM [School].[dbo].[Person] as student
                    JOIN [School].[dbo].[StudentGrade] as grade
                        ON student.PersonID = grade.StudentID
                    JOIN [School].[dbo].[Course] as course
                        ON grade.CourseID = course.CourseID
                WHERE student.Discriminator = 'Student' AND grade.Grade IS NOT NULL
                GROUP BY PersonID, FirstName, LastName
            ").ToListAsync();
        }

        public bool Exists(int studentId)
        {
            return _context.Persons.Any(s => s.PersonID == studentId && s.Discriminator == STUDENT_DISCRIMINATOR);
        }

        private async Task<Transcript> CreateStudentTranscript(Person person)
        {
            var transcript = new Transcript(person);

            var grades = await _gradesRepo.GetByStudentId(transcript.StudentId);
            transcript.Grades = grades;
            transcript.Gpa = grades.Any() ? GpaCalculator.Calculate(grades) : 0;

            return transcript;
        }
    }
}
