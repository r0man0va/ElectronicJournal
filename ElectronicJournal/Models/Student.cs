using System.ComponentModel.DataAnnotations;

namespace ElectronicJournal.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Display(Name="Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Группа")]
        public string GroupName { get; set;  }
       
        [Display(Name = "Дата рождения")]
        public DateTime DOB { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber {get; set; }

        [Display(Name = "Дата зачисления")]
        public DateTime EnrollmentDate { get; set; }  // дата зачисления на курс
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}