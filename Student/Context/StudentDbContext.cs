using Microsoft.EntityFrameworkCore;

namespace Student.Context
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student.Entities.Student> Students { get; set; }
        public DbSet<Student.Entities.CourseStudent> CourseStudents { get; set; }
        public DbSet<Student.Entities.CourseTeacher> CourseTeachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student.Entities.Student>()
                .ToTable("Students", schema: "S");
            modelBuilder.Entity<Student.Entities.CourseTeacher>()
            .ToTable("CourseTeachers", schema: "Shared");
            modelBuilder.Entity<Student.Entities.CourseStudent>()
            .ToTable("CourseStudents", schema: "Shared");
        }
    }
}
