using Microsoft.EntityFrameworkCore;

namespace student_api.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PersonSetup(modelBuilder);
            StudentGradeSetup(modelBuilder);
        }

        private void PersonSetup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .ToTable("Person")
                .HasKey(p => p.PersonID);
        }

        private void CourseSetup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .ToTable("Course")
                .HasKey(c => c.CourseID);
        }

        private void StudentGradeSetup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentGrade>()
                .ToTable("StudentGrade")
                .HasKey(s => s.EnrollmentID);
        }
    }
}
