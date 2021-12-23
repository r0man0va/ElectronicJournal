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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}