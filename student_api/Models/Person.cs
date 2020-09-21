using System;
using System.ComponentModel.DataAnnotations;

namespace student_api.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Discriminator { get; set; }
    }
}
