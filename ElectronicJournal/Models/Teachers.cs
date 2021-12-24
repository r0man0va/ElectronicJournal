using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicJournal.Models
{
    public class Teacher
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime DOB { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Полное имя")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        [Display(Name = "Кафедра")]
        public Department Department { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}