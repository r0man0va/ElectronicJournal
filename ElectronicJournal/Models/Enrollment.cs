using System.ComponentModel.DataAnnotations;

namespace ElectronicJournal.Models
{
    public enum Grade
    {
        Удовлетворительно = 3,
        Хорошо,
        Отлично
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "Нет оценки")]
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}