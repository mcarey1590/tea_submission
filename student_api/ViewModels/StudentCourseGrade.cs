using System;
using student_api.Models;

namespace student_api.ViewModels
{
    public class StudentCourseGrade
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public decimal? Grade { get; set; }

        public StudentCourseGrade() { }
        public StudentCourseGrade(StudentGrade grade)
        {
            CourseId = grade.CourseID;
            Title = grade.Course.Title;
            Credits = grade.Course.Credits;
            Grade = grade.Grade.Value;
        }
    }
}
