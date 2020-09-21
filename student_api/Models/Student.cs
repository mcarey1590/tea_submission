namespace student_api.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Gpa { get; set; }

        public Student() { }

        public Student(Person person)
        {
            StudentId = person.PersonID;
            FirstName = person.FirstName;
            LastName = person.LastName;
        }
    }
}
