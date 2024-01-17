using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Teacher.Entities;

namespace Teacher.Context
{
    public class TeacherDbContext : DbContext
    {
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
        {
        }

        public DbSet<Teacher.Entities.Teacher> Teachers { get; set; }
        public DbSet<Teacher.Entities.CourseStudent> CourseStudents { get; set; }
        public DbSet<Teacher.Entities.CourseTeacher> CourseTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher.Entities.Teacher>()
                .ToTable("Teachers", schema: "T");
            modelBuilder.Entity<Teacher.Entities.CourseTeacher>()
            .ToTable("CourseTeachers", schema: "Shared");
            modelBuilder.Entity<Teacher.Entities.CourseStudent>()
            .ToTable("CourseStudents", schema: "Shared");
        }
    }
}
