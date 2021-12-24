using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicJournal.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Код курса")]
        public int CourseID { get; set; }
        [Display(Name = "Название курса")]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Teacher> Teachers { get; set; }

    }
}