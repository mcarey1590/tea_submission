using System.ComponentModel.DataAnnotations;

namespace student_api.Models
{
    public class StudentGrade
    {
        public int EnrollmentID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Range(0.00, 4.00)]
        public decimal? Grade { get; set; }

        public Course Course { get; set; }
    }
}
