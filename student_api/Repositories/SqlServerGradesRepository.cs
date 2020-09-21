using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using student_api.Models;
using student_api.ViewModels;

namespace student_api.Repositories
{
    public class SqlServerGradesRepository: IGradesRepository
    {
        private readonly SchoolContext _context;

        public SqlServerGradesRepository(SchoolContext context)
        {
            _context = context;
        }

        public StudentGrade AddGrade(StudentGrade studentGrade)
        {
            var existing = GetCourseGrade(studentGrade.StudentID, studentGrade.CourseID);
            if(existing != null)
            {
                _context.StudentGrades.Remove(existing);
            }
            _context.StudentGrades.Add(studentGrade);
            _context.SaveChanges();
            return studentGrade;
        }

        public async Task<IEnumerable<StudentCourseGrade>> GetByStudentId(int studentId)
        {
            return await _context.StudentGrades
                .Where(g => g.StudentID == studentId && g.Grade != null)
                .Include("Course")
                .Select(g => new StudentCourseGrade(g))
                .ToListAsync();
        }

        private StudentGrade GetCourseGrade(int studentId, int courseId)
        {
            return _context.StudentGrades.Where(s => s.StudentID == studentId && s.CourseID == courseId).FirstOrDefault();
        }
    }
}
