using Course.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Course.Context
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {
        }

        public DbSet<Course.Entities.Course> Courses { get; set; }
        public DbSet<Course.Entities.CourseStudent> CourseStudents { get; set; }
        public DbSet<Course.Entities.CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Course.Entities.Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course.Entities.Course>()
                .ToTable("Courses", schema: "C");
            modelBuilder.Entity<Course.Entities.CourseTeacher>()
            .ToTable("CourseTeachers", schema: "Shared");
            modelBuilder.Entity<Course.Entities.CourseStudent>()
            .ToTable("CourseStudents", schema: "Shared");
            modelBuilder.Entity<Course.Entities.Book>()
                .ToTable("Books", schema: "C");
        }
    }
}
