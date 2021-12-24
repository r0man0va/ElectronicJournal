using ElectronicJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicJournal.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ElectronicJournalContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            var shestakov = new Student
            {
                FirstName = "Андрей",
                LastName = "Шестаков",
                EnrollmentDate = DateTime.Parse("2016-09-01"),
                GroupName = "Би-31",
                DOB = DateTime.Parse("2001-01-01"),
                PhoneNumber = "89024304920",
            };

            var romanova = new Student
            {
                FirstName = "Татьяна",
                LastName = "Романова",
                EnrollmentDate = DateTime.Parse("2018-09-01"),
                GroupName = "Би-32",
                DOB = DateTime.Parse("2001-01-01"),
                PhoneNumber = "89024304920",
            };

            var egoshin = new Student
            {
                FirstName = "Алексей",
                LastName = "Егошин",
                EnrollmentDate = DateTime.Parse("2019-09-01"),
                GroupName = "Би-31",
                DOB = DateTime.Parse("2001-01-01"),
                PhoneNumber = "89024304920",
            };

            var parfonova = new Student
            {
                FirstName = "Анастасия",
                LastName = "Парфёнова",
                EnrollmentDate = DateTime.Parse("2018-09-01"),
                GroupName = "Би-32",
                DOB = DateTime.Parse("2001-01-01"),
                PhoneNumber = "89024304920",
            };

            var katin = new Student
            {
                FirstName = "Михаил",
                LastName = "Катин",
                EnrollmentDate = DateTime.Parse("2018-09-01"),
                GroupName = "Би-31",
                DOB = DateTime.Parse("2001-01-01"),
                PhoneNumber = "89024304920",
            };

            var davidov = new Student
            {
                FirstName = "Антон",
                LastName = "Давыдов",
                EnrollmentDate = DateTime.Parse("2017-09-01"),
                GroupName = "Би-32",
                DOB = DateTime.Parse("2001-01-01"),
                PhoneNumber = "89024304920",
            };

            var poscrebishev = new Student
            {
                FirstName = "Алексей",
                LastName = "Поскрёбышев",
                EnrollmentDate = DateTime.Parse("2019-09-01"),
                GroupName = "Би-31",
                DOB = DateTime.Parse("2001-01-01"),
                PhoneNumber = "89024304920",
            };

            var akatov = new Student
            {
                FirstName = "Константин",
                LastName = "Акатов",
                EnrollmentDate = DateTime.Parse("2011-09-01"),
                GroupName = "Би-32",
                DOB = DateTime.Parse("2001-01-01"),
                PhoneNumber = "89024304920",
            };

            var vanasin = new Teacher
            {
                FirstName = "Никита",
                LastName = "Ванясин",
                DOB = DateTime.Parse("1995-03-11"),
                PhoneNumber = "89024304920",
            };

            var smirnov = new Teacher
            {
                FirstName = "Владимир",
                LastName = "Смирнов",
                DOB = DateTime.Parse("2002-07-06"),
                PhoneNumber = "89024304920",
            };

            var sorokin = new Teacher
            {
                FirstName = "Олег",
                LastName = "Сорокин",
                DOB = DateTime.Parse("1998-07-01"),
                PhoneNumber = "89024304920",
            };

            var tukaev = new Teacher
            {
                FirstName = "Андрей",
                LastName = "Тюкаев",
                DOB = DateTime.Parse("2001-01-15"),
                PhoneNumber = "89024304920",
            };

            var artamonova = new Teacher
            {
                FirstName = "Анна",
                LastName = "Артамонова",
                DOB = DateTime.Parse("2004-02-12"),
                PhoneNumber = "89024304920",
            };

            var database = new Department
            {
                Name = "Базы Данных",
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = tukaev
            };

            var mathematics = new Department
            {
                Name = "Высшая математика",
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = smirnov
            };

            var filosofia = new Department
            {
                Name = "Философия",
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = artamonova
            };

            var safetydatabase = new Course
            {
                CourseID = 10,
                Title = "Безопасность базы данных",
                Department = database,
                Teachers = new List<Teacher> { tukaev, vanasin }
            };

            var tokb = new Course
            {
                CourseID = 11,
                Title = "ТОКБ",
                Department = database,
                Teachers = new List<Teacher> { smirnov, tukaev }
            };

            var algebra = new Course
            {
                CourseID = 20,
                Title = "Алгебра",
                Department = mathematics,
                Teachers = new List<Teacher> { tukaev }
            };

            var geometria = new Course
            {
                CourseID = 21,
                Title = "Геометрия",
                Department = mathematics,
                Teachers = new List<Teacher> { vanasin }
            };

            var lifp = new Course
            {
                CourseID = 22,
                Title = "ЛиФП",
                Department = mathematics,
                Teachers = new List<Teacher> { smirnov, vanasin, sorokin }
            };

            var history = new Course
            {
                CourseID = 30,
                Title = "История",
                Department = filosofia,
                Teachers = new List<Teacher> { artamonova, smirnov }
            };

            var kyltura = new Course
            {
                CourseID = 31,
                Title = "Культура",
                Department = filosofia,
                Teachers = new List<Teacher> { artamonova, sorokin }
            };

            var enrollments = new Enrollment[]
            {
                    new Enrollment { Student = shestakov, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = shestakov, Course = algebra, Grade = Grade.Отлично },
                    new Enrollment { Student = shestakov, Course = lifp, Grade = Grade.Отлично },
                    new Enrollment { Student = shestakov, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = shestakov, Course = history, Grade = Grade.Отлично },
                    new Enrollment { Student = shestakov, Course = geometria, Grade = Grade.Отлично },
                    new Enrollment { Student = shestakov, Course = kyltura, Grade = Grade.Отлично },

                    new Enrollment { Student = romanova, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = romanova, Course = algebra, Grade = Grade.Отлично },
                    new Enrollment { Student = romanova, Course = lifp, Grade = Grade.Отлично },
                    new Enrollment { Student = romanova, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = romanova, Course = history, Grade = Grade.Отлично },
                    new Enrollment { Student = romanova, Course = geometria, Grade = Grade.Отлично },
                    new Enrollment { Student = romanova, Course = kyltura, Grade = Grade.Отлично },

                    new Enrollment { Student = egoshin, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = egoshin, Course = algebra, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = egoshin, Course = lifp, Grade = Grade.Хорошо },
                    new Enrollment { Student = egoshin, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = egoshin, Course = history, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = egoshin, Course = geometria, Grade = Grade.Хорошо },
                    new Enrollment { Student = egoshin, Course = kyltura, Grade = Grade.Отлично },

                    new Enrollment { Student = parfonova, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = parfonova, Course = algebra, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = parfonova, Course = lifp, Grade = Grade.Хорошо },
                    new Enrollment { Student = parfonova, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = parfonova, Course = history, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = parfonova, Course = geometria, Grade = Grade.Хорошо },
                    new Enrollment { Student = parfonova, Course = kyltura, Grade = Grade.Отлично },

                    new Enrollment { Student = katin, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = katin, Course = algebra, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = katin, Course = lifp, Grade = Grade.Хорошо },
                    new Enrollment { Student = katin, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = katin, Course = history, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = katin, Course = geometria, Grade = Grade.Хорошо },
                    new Enrollment { Student = katin, Course = kyltura, Grade = Grade.Отлично },

                    new Enrollment { Student = davidov, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = davidov, Course = algebra, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = davidov, Course = lifp, Grade = Grade.Хорошо },
                    new Enrollment { Student = davidov, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = davidov, Course = history, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = davidov, Course = geometria, Grade = Grade.Хорошо },
                    new Enrollment { Student = davidov, Course = kyltura, Grade = Grade.Отлично },

                    new Enrollment { Student = poscrebishev, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = poscrebishev, Course = algebra, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = poscrebishev, Course = lifp, Grade = Grade.Хорошо },
                    new Enrollment { Student = poscrebishev, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = poscrebishev, Course = history, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = poscrebishev, Course = geometria, Grade = Grade.Хорошо },
                    new Enrollment { Student = poscrebishev, Course = kyltura, Grade = Grade.Отлично },

                    new Enrollment { Student = akatov, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = akatov, Course = algebra, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = akatov, Course = lifp, Grade = Grade.Хорошо },
                    new Enrollment { Student = akatov, Course = tokb, Grade = Grade.Отлично },
                    new Enrollment { Student = akatov, Course = history, Grade = Grade.Удовлетворительно },
                    new Enrollment { Student = akatov, Course = geometria, Grade = Grade.Хорошо },
                    new Enrollment { Student = akatov, Course = kyltura, Grade = Grade.Отлично },
            };

            context.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}