using System.Collections.Generic;
using student_api.Models;

namespace student_api.ViewModels
{
    public class Transcript: Student
    {
        public IEnumerable<StudentCourseGrade> Grades { get; set; }

        public Transcript() { }

        public Transcript(Person person): base(person)
        {
        }
    }
}
