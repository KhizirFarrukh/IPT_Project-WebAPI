using CourseRegistration_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace CourseRegistration_WebAPI.Data
{
    public class CourseRegistrationDbContext : DbContext
    {
        public CourseRegistrationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Core Course Foreign keys
            modelBuilder.Entity<CoreCourse>()
                .HasOne<TheoryCourse>()
                .WithOne()
                .HasForeignKey<CoreCourse>(p => p.id);

            modelBuilder.Entity<CoreCourse>()
                .HasOne<CoreCourse>()
                .WithOne()
                .HasForeignKey<CoreCourse>(p => p.prevChainID);

            // Lab Course Foreign keys
            modelBuilder.Entity<LabCourse>()
                .HasOne<Course>()
                .WithOne()
                .HasForeignKey<LabCourse>(p => p.id);

            modelBuilder.Entity<LabCourse>()
                .HasOne<TheoryCourse>()
                .WithOne()
                .HasForeignKey<LabCourse>(p => p.theoryID);

            // TheoryCourse Foreign keys
            modelBuilder.Entity<TheoryCourse>()
                .HasOne<Course>()
                .WithOne()
                .HasForeignKey<TheoryCourse>(p => p.id);

            // Course Foreign key
            modelBuilder.Entity<Course>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(p => p.deptID);

            // Course Log Foreign keys
            modelBuilder.Entity<CourseLog>()
                .HasOne<Course>()
                .WithMany()
                .HasForeignKey(p => p.courseID);

            modelBuilder.Entity<CourseLog>()
               .HasOne<Teacher>()
               .WithMany()
               .HasForeignKey(p => p.teacherID);

            modelBuilder.Entity<CourseLog>()
                .HasOne<Section>()
                .WithMany()
                .HasForeignKey(p => p.sectionID);

            // Student Foreign key
            modelBuilder.Entity<Student>()
                .HasOne<Section>()
                .WithMany()
                .HasForeignKey(p => p.sectionID);

            // Student Login Foreign key
            modelBuilder.Entity<StudentLogin>()
                .HasOne<Student>()
                .WithOne()
                .HasForeignKey<StudentLogin>(p => p.studentID);

            // RegisteredCourses Foreign keys
            modelBuilder.Entity<RegisteredCourse>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(p => p.studentID);

            modelBuilder.Entity<RegisteredCourse>()
                .HasOne<CourseLog>()
                .WithMany()
                .HasForeignKey(p => p.courseLogID);

            // Section Foreign keys
            modelBuilder.Entity<Section>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(p => p.deptID);


        }
        public DbSet<CoreCourse> CoreCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLog> CourseLogs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LabCourse> LabCourses { get; set; }
        public DbSet<RegisteredCourse> RegisteredCourses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLogin> StudentLogins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TheoryCourse> TheoryCourses { get; set; }
    }
}
