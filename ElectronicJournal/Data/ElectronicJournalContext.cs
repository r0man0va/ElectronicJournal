using Microsoft.EntityFrameworkCore;
using ElectronicJournal.Models;

namespace ElectronicJournal.Data
{
    public class ElectronicJournalContext : DbContext
    {
        public ElectronicJournalContext(DbContextOptions<ElectronicJournalContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable(nameof(Course))
                .HasMany(c => c.Teachers)
                .WithMany(i => i.Courses);
            modelBuilder.Entity<Student>().ToTable(nameof(Student));
            modelBuilder.Entity<Teacher>().ToTable(nameof(Teacher));
        }
    }
}