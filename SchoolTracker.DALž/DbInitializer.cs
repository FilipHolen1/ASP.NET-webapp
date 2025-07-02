using System.Collections.Generic;
using System.Linq;
using SchoolTracker.Model;

namespace SchoolTracker.DAL
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
       
            if (context.Students.Any()) return;

            // Seed Professors
            var professors = new List<Profesor>
            {
                new Profesor { FirstName = "Ana", LastName = "Anić", Email = "ana.anic@example.com" },
                new Profesor { FirstName = "Marko", LastName = "Marić", Email = "marko.maric@example.com" }
            };
            context.Profesors.AddRange(professors);
            context.SaveChanges();

            // Seed Class Years
            var classYears = new List<ClassYear>
            {
                new ClassYear { Name = "1A" },
                new ClassYear { Name = "2B" }
            };
            context.ClassYears.AddRange(classYears);
            context.SaveChanges();

            // Seed Subjects
            var subjects = new List<Subject>
            {
                new Subject { Name = "Matematika", ProfesorID = professors[0].ID },
                new Subject { Name = "Fizika", ProfesorID = professors[1].ID }
            };
            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            // Seed Students
            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "Ivić",
                    Email = "ivan.ivic@example.com",
                    ClassYearID = classYears[0].ID,
                    DateOfBirth = new System.DateTime(2008, 5, 20)
                },
                new Student
                {
                    FirstName = "Petra",
                    LastName = "Petrić",
                    Email = "petra.petric@example.com",
                    ClassYearID = classYears[1].ID,
                    DateOfBirth = new System.DateTime(2009, 3, 15)
                }
            };
            context.Students.AddRange(students);
            context.SaveChanges();

            // Seed Grades
            var grades = new List<Grade>
            {
                new Grade { StudentID = students[0].ID, SubjectID = subjects[0].ID, Value = 5 },
                new Grade { StudentID = students[1].ID, SubjectID = subjects[1].ID, Value = 4 }
            };
            context.Grades.AddRange(grades);
            context.SaveChanges();
        }
    }
}
