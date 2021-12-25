using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicJournal.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Дата основания")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Администратор")]
        public int? TeacherID { get; set; }
        [Display(Name = "Администратор")]
        public Teacher Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}