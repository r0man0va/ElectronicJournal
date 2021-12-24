using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicJournal.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Фамилия")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Имя не может быть длиннее, чем 50 символов.")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Полное имя")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [Required]
        [StringLength(10, MinimumLength = 2)]
        [Display(Name = "Группа")]
        public string GroupName { get; set;  }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime DOB { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber {get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата зачисления")]
        public DateTime EnrollmentDate { get; set; }  // дата зачисления на курс
        [Display(Name = "Назначенные курсы")]

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}