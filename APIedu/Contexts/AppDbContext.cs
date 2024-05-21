using APIedu.Models;
using Microsoft.EntityFrameworkCore;

namespace APIedu.Contexts
{
    public class AppDbContext : DbContext
    {
        // Propertys
        public virtual DbSet<Course> TbCourses { get; set; }
        public virtual DbSet<Lesson> TbLessons { get; set; }
        public virtual DbSet<StudentInfo> TbStudentInfo { get; set; }
        public virtual DbSet<CourseStudentInfo> TbCourseStudentInfo { get; set;}

        //Constractor 
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }

        // On Model Creating Function 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
