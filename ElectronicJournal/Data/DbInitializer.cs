using ElectronicJournal.Models;

namespace ElectronicJournal.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ElectronicJournalContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstName="Эвелина",LastName="Антипова",EnrollmentDate=DateTime.Parse("2019-09-01"),PhoneNumber = "89024304920", DOB = DateTime.Parse("2001-01-01"), GroupName = "Би-31" },
                new Student{FirstName="Татьяна",LastName="Романова",EnrollmentDate=DateTime.Parse("2017-09-01"), PhoneNumber = "88353838620", DOB = DateTime.Parse("2001-11-01"), GroupName = "Би-32"},
                new Student{FirstName="Виктория",LastName="Булатова",EnrollmentDate=DateTime.Parse("2018-09-01"), PhoneNumber = "86462107289", DOB = DateTime.Parse("2001-10-01"), GroupName = "Би-31"},
                new Student{FirstName="Никита",LastName="Глазырин",EnrollmentDate=DateTime.Parse("2017-09-01"), PhoneNumber = "86562887754", DOB = DateTime.Parse("2001-09-01"), GroupName = "Би-32"},
                new Student{FirstName="Анна",LastName="Егорова",EnrollmentDate=DateTime.Parse("2017-09-01"), PhoneNumber = "88987374551", DOB = DateTime.Parse("2001-08-01"), GroupName = "Би-31"},
                new Student{FirstName="Антон",LastName="Давыдов",EnrollmentDate=DateTime.Parse("2016-09-01"), PhoneNumber = "81321140027", DOB = DateTime.Parse("2001-02-01"), GroupName = "Би-32"},
                new Student{FirstName="Роман",LastName="Мухлыгин",EnrollmentDate=DateTime.Parse("2018-09-01"),PhoneNumber = "89957623182", DOB = DateTime.Parse("2001-01-01"), GroupName = "Би-31"},
                new Student{FirstName="Сергей",LastName="Патрушев",EnrollmentDate=DateTime.Parse("2019-09-01"), PhoneNumber = "86034499501", DOB = DateTime.Parse("2001-09-01"), GroupName = "Би-32"}
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=10,Title="Химия"},
                new Course{CourseID=20,Title="Микроэкономика"},
                new Course{CourseID=21,Title="Макроэкономика"},
                new Course{CourseID=30,Title="Безопасность Базы Данных"},
                new Course{CourseID=31,Title="ФОТСОИБ"},
                new Course{CourseID=32,Title="ТОКБ"},
                new Course{CourseID=40,Title="Философия"}
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=10,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=1,CourseID=20,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=1,CourseID=21,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=1,CourseID=30,Grade=Grade.Отлично},
                new Enrollment{StudentID=1,CourseID=31,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=1,CourseID=32,Grade=Grade.Хорошо},
                new Enrollment{StudentID=1,CourseID=40,Grade=Grade.Удовлетворительно},

                new Enrollment{StudentID=2,CourseID=10,Grade=Grade.Отлично},
                new Enrollment{StudentID=2,CourseID=20,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=2,CourseID=21,Grade=Grade.Хорошо},
                new Enrollment{StudentID=2,CourseID=30,Grade=Grade.Отлично},
                new Enrollment{StudentID=2,CourseID=31,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=2,CourseID=32,Grade=Grade.Хорошо},
                new Enrollment{StudentID=2,CourseID=40,Grade=Grade.Хорошо},

                new Enrollment{StudentID=3,CourseID=10,Grade=Grade.Отлично},
                new Enrollment{StudentID=3,CourseID=20,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=3,CourseID=21,Grade=Grade.Хорошо},
                new Enrollment{StudentID=3,CourseID=30,Grade=Grade.Отлично},
                new Enrollment{StudentID=3,CourseID=31,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=3,CourseID=32,Grade=Grade.Хорошо},
                new Enrollment{StudentID=3,CourseID=40,Grade=Grade.Хорошо},

                new Enrollment{StudentID=4,CourseID=10,Grade=Grade.Отлично},
                new Enrollment{StudentID=4,CourseID=20,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=4,CourseID=21,Grade=Grade.Хорошо},
                new Enrollment{StudentID=4,CourseID=30,Grade=Grade.Отлично},
                new Enrollment{StudentID=4,CourseID=31,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=4,CourseID=32,Grade=Grade.Хорошо},
                new Enrollment{StudentID=4,CourseID=40,Grade=Grade.Хорошо},

                new Enrollment{StudentID=5,CourseID=10,Grade=Grade.Отлично},
                new Enrollment{StudentID=5,CourseID=20,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=5,CourseID=21,Grade=Grade.Хорошо},
                new Enrollment{StudentID=5,CourseID=30,Grade=Grade.Отлично},
                new Enrollment{StudentID=5,CourseID=31,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=5,CourseID=32,Grade=Grade.Хорошо},
                new Enrollment{StudentID=5,CourseID=40,Grade=Grade.Хорошо},

                new Enrollment{StudentID=6,CourseID=10,Grade=Grade.Отлично},
                new Enrollment{StudentID=6,CourseID=20,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=6,CourseID=21,Grade=Grade.Хорошо},
                new Enrollment{StudentID=6,CourseID=30,Grade=Grade.Отлично},
                new Enrollment{StudentID=6,CourseID=31,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=6,CourseID=32,Grade=Grade.Хорошо},
                new Enrollment{StudentID=6,CourseID=40,Grade=Grade.Хорошо},

                new Enrollment{StudentID=7,CourseID=10,Grade=Grade.Отлично},
                new Enrollment{StudentID=7,CourseID=20,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=7,CourseID=21,Grade=Grade.Хорошо},
                new Enrollment{StudentID=7,CourseID=30,Grade=Grade.Отлично},
                new Enrollment{StudentID=7,CourseID=31,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=7,CourseID=32,Grade=Grade.Хорошо},
                new Enrollment{StudentID=7,CourseID=40,Grade=Grade.Хорошо},

                new Enrollment{StudentID=8,CourseID=10,Grade=Grade.Отлично},
                new Enrollment{StudentID=8,CourseID=20,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=8,CourseID=21,Grade=Grade.Хорошо},
                new Enrollment{StudentID=8,CourseID=30,Grade=Grade.Отлично},
                new Enrollment{StudentID=8,CourseID=31,Grade=Grade.Удовлетворительно},
                new Enrollment{StudentID=8,CourseID=32,Grade=Grade.Хорошо},
                new Enrollment{StudentID=8,CourseID=40,Grade=Grade.Хорошо}
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}