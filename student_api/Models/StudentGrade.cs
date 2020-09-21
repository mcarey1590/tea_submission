using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace student_api.Models
{
    public class StudentGrade
    {
        [JsonPropertyName("gradeId")]
        public int EnrollmentID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Range(0.00, 4.00)]
        public decimal? Grade { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
    }
}
