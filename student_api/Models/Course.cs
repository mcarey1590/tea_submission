using System.ComponentModel.DataAnnotations;

namespace student_api.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}
