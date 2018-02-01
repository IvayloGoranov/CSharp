using System.Linq;
using System;

using StudentSystem.Data;

namespace StudentSystem.Client
{
    public class StudentSystemMain
    {
        public static void Main()
        {
            var context = new StudentSystemContext();

            var studentsAndHomeworks = context.Students.Select(s =>
            new
            {
                Name = s.StudentName,
                Homeworks = s.Homeworks.Select(h =>
                new
                {
                    Content = h.HomeworkContent,
                    Type = h.HomeworkContentType
                })
            });

            foreach (var student in studentsAndHomeworks)
            {
                Console.WriteLine("{0}: ", student.Name);
                Console.WriteLine(string.Join(Environment.NewLine, student.Homeworks));
            }

            Console.WriteLine();
            Console.WriteLine();

            var coursesAndResources = context.Courses.OrderBy(c => c.StartDate).
                ThenByDescending(c => c.EndDate).
                Select(c =>
            new
            {
                Name = c.CourseName,
                Description = c.Description,
                Resources = c.Resources
            });

            foreach (var course in coursesAndResources)
            {
                Console.WriteLine("{0}, {1} ", course.Name, course.Description);
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine("{0}, {1}, {2}", resource.ResourceName,
                        resource.ResourceType, resource.URL);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            var coursesWithMoreThan5Resources = context.Courses.
                Where(c => c.Resources.Count >= 2).
                OrderByDescending(c => c.Resources.Count).
                ThenByDescending(c => c.StartDate).
                Select(c =>
                        new
                        {
                            Name = c.CourseName,
                            ResourceCount = c.Resources.Count
                        });

            foreach (var course in coursesWithMoreThan5Resources)
            {
                Console.WriteLine("{0}, Resource count: {1} ", course.Name, course.ResourceCount);
            }

            Console.WriteLine();
            Console.WriteLine();

            var studentInfo = context.Students.
                Select(s =>
                        new {
                            Name = s.StudentName,
                            CoursesCount = s.Courses.Count,
                            CoursesSum = s.Courses.Sum(c => c.Price),
                            AverageCoursePrice = s.Courses.Average(c => c.Price)
                        });

            foreach (var info in studentInfo)
            {
                Console.WriteLine("Name: {0}, Courses count: {1}, Courses sum: {2}, Avg price: {3} ", 
                    info.Name, info.CoursesCount, info.CoursesSum, info.AverageCoursePrice);
            }
        }
    }
}
