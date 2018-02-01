using System.Collections.Generic;
using System.Data.Entity.Migrations;

using StudentSystem.Models;
using System;
using System.Linq;

namespace StudentSystem.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemContext";
        }

        protected override void Seed(StudentSystemContext context)
        {
            this.SeedStudents(context);
            this.SeedCourses(context);
            this.SeedHomeworks(context);
            this.SeedResources(context);
        }

        private void SeedResources(StudentSystemContext context)
        {
            Course databaseBasics = context.Courses.First(c => c.CourseName == "Database Basics");

            var lecture = new Resource
            {
                ResourceName = "Lecture_1_Slides",
                ResourceType = ResourceType.Presentation,
                URL = "http://softuni.bg/something",
                Course = databaseBasics
            };

            var lectureInDataBase = context.Resources.Where(
               h =>
                    h.ResourceName == lecture.ResourceName).SingleOrDefault();

            if (lectureInDataBase == null)
            {
                context.Resources.Add(lecture);
            }

            var homework = new Resource
            {
                ResourceName = "Homework_1",
                ResourceType = ResourceType.Document,
                URL = "http://softuni.bg/something2",
                Course = databaseBasics
            };

            var homeworkInDataBase = context.Resources.Where(
               h =>
                    h.ResourceName == homework.ResourceName).SingleOrDefault();

            if (homeworkInDataBase == null)
            {
                context.Resources.Add(homework);
            }

            context.SaveChanges();
        }

        private void SeedHomeworks(StudentSystemContext context)
        {
            foreach (var student in context.Students)
            {
                var homework = new Homework
                {
                    HomeworkContent = "homework.zip",
                    HomeworkContentType = HomeworkContentType.Application_Zip,
                    SubmissionDate = new DateTime(2016, 10, 3),
                    Student = student,
                    Course = student.Courses.First(),
                    StudentId = student.Id,
                    CourseId = student.Courses.First().Id
                };

                var homeworkInDataBase = context.Homeworks.Where(
                   h =>
                        h.Student.Id == homework.StudentId &&
                        h.Course.Id == h.CourseId).SingleOrDefault();

                if (homeworkInDataBase == null)
                {
                    context.Homeworks.Add(homework);
                }
            }

            context.SaveChanges();
        }

        private void SeedCourses(StudentSystemContext context)
        {
            var courses = new List<Course>
            {
                new Course { CourseName = "Database Applications",
                    StartDate = new DateTime(2016, 11, 1),
                    EndDate = new DateTime(2016, 11, 30),
                    Price = 200},
                 new Course { CourseName = "Database Basics",
                    StartDate = new DateTime(2016, 10, 1),
                    EndDate = new DateTime(2016, 10, 31),
                    Price = 200}
            };

            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseName, s));
            context.SaveChanges();

            Course databaseBasics = context.Courses.First(c => c.CourseName == "Database Basics");

            foreach (var student in context.Students)
            {
                student.Courses.Add(databaseBasics);
            }

            context.SaveChanges();
        }

        private void SeedStudents(StudentSystemContext context)
        {
            var students = new List<Student>
            {
                new Student { StudentName = "Carson Alexander",
                    RegistrationDate = new DateTime(2012, 9, 1),
                    Birthdate = (DateTime?)new DateTime(1984, 10, 18)},
                new Student { StudentName = "Meredith Alonso",
                    RegistrationDate = new DateTime(2012, 9, 1),
                    Birthdate = (DateTime?)new DateTime(1985, 10, 18)},
                new Student { StudentName = "Arturo Anand",
                    RegistrationDate = new DateTime(2013, 9, 1),
                    Birthdate = (DateTime?)new DateTime(1986, 10, 18)},
                new Student { StudentName = "Gytis Barzdukas",
                    RegistrationDate = new DateTime(2012, 9, 1),
                    Birthdate = (DateTime?)new DateTime(1987, 10, 18)},
                new Student { StudentName = "Yan Li",
                    RegistrationDate = new DateTime(2012, 9, 1),
                    Birthdate = (DateTime?)new DateTime(1988, 10, 18)},
                new Student { StudentName = "Peggy Justice",
                    RegistrationDate = new DateTime(2011, 9, 1),
                    Birthdate = (DateTime?)new DateTime(1989, 10, 18)},
                new Student { StudentName = "Laura Norman",
                    RegistrationDate = new DateTime(2011, 9, 1),
                    Birthdate = (DateTime?)new DateTime(1990, 10, 18)},
                new Student { StudentName = "Nino Olivetto",
                    RegistrationDate = new DateTime(2005, 9, 1),
                    Birthdate = (DateTime?)new DateTime(1991, 10, 18)}
            };

            students.ForEach(s => context.Students.AddOrUpdate(p => p.StudentName, s));
            context.SaveChanges();
        }
    }
}
