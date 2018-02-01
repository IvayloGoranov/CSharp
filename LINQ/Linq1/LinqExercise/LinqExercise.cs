using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Text;

namespace LinqExercise
{
    public class LinqExercise
    {
        public static void Main()
        {
            const string FilePath = @"../../Students-data.txt";

            List<Student> students = new List<Student>();

            bool hasHeader = CheckFileForHeaderExistence(FilePath);
            List<string> fileLines = ReadFileLines(FilePath, hasHeader);
            CreateStudentsFromFileInfo(students, fileLines);

            //IEnumerable<Student> allMaleStudents = ExtractAllMaleStudents(students);
            //PrintQueryResult(allMaleStudents);

            //IEnumerable<Student> allStudentsFirstNameStartsWithA = ExtractFirstNameStartsWithA(students);
            //PrintQueryResult(allStudentsFirstNameStartsWithA);

            //IEnumerable<Student> allStudentsByExamScoreGreaterThan300 = ExtractStudentsByExamScoreGreaterThan300(students);
            //foreach (var student in allStudentsByExamScoreGreaterThan300)
            //{
            //    Console.WriteLine(student + " - " + student.ExamResult);
            //}

            //IEnumerable<Student> allStudentsWithoutHomeworkSent = ExtractStudentsWithoutHomeworkSent(students);
            //PrintQueryResult(allStudentsWithoutHomeworkSent);

            //var onsiteStudentsEmails =
            //    from student in students
            //    where student.HomeworksSent == 0
            //    orderby student.StudentType == "Onsite"
            //    select new { Email = student.Email};
            //PrintQueryResult(onsiteStudentsEmails);

            //var examResultsAttendanceCountsOfStudentsWithLessThanFiveAttendances =
            //    from student in students
            //    where student.AttendancesCount < 5
            //    select new { Result = student.ExamResult, Attendancies = student.AttendancesCount };
            //PrintQueryResult(examResultsAttendanceCountsOfStudentsWithLessThanFiveAttendances);

            //var allStudentsWithBonusFourOrMore =
            //    from student in students
            //    where student.Bonus >= 4
            //    select student;
            //int allStudentsWithBonusFourOrMoreCount = allStudentsWithBonusFourOrMore.Count();
            //Console.WriteLine(allStudentsWithBonusFourOrMoreCount);

            //double averageExamScoreOfAllOnsiteStudents = FindAverageExamScoreOfAllOnsiteStudents(students);
            //Console.WriteLine(averageExamScoreOfAllOnsiteStudents);

            //GroupStudentsByFirstNameInitials(students);

            var allOnsiteStudents =
                from student in students
                where student.StudentType == "Onsite"
                select student;

            var allOnsiteStudentsSorted =
                from student in allOnsiteStudents
                orderby student.ExamResult descending
                select student;

            StringBuilder output = new StringBuilder(allOnsiteStudentsSorted.Count());
            foreach (var student in allOnsiteStudentsSorted)
            {
                output.AppendFormat(" {0} {1} - {2}{3}", 
                    student.FirstName, student.LastName, student.ExamResult, Environment.NewLine);
            }

            Console.WriteLine("Onsite");
            Console.WriteLine(output);
        }

        private static void GroupStudentsByFirstNameInitials(List<Student> students)
        {
            var groupsByFirstNameInitials =
                from student in students
                group student by student.FirstName[0] into groupByFirstNameInitial
                select new { FirstNameInitial = groupByFirstNameInitial.Key, Students = groupByFirstNameInitial };

            var groupsByFirstNameInitialsSorted =
                from groupByFirstNameInitial in groupsByFirstNameInitials
                orderby groupByFirstNameInitial.FirstNameInitial
                select groupByFirstNameInitial;

            foreach (var group in groupsByFirstNameInitialsSorted)
            {
                Console.WriteLine(group.FirstNameInitial);
                StringBuilder output = new StringBuilder(group.Students.Count() * 2);
                foreach (var student in group.Students)
                {
                    output.AppendFormat(" {0} {1}{2}", student.FirstName, student.LastName, Environment.NewLine);
                }

                Console.WriteLine(output);
            }
        }

        private static double FindAverageExamScoreOfAllOnsiteStudents(List<Student> students)
        {
            var allOnsiteStudents =
                from student in students
                where student.StudentType == "Onsite"
                select student;
            
            int allExamScoresTotal = allOnsiteStudents.Sum(student => student.ExamResult);
            double averageExamScoreOfAllOnsiteStudents = allExamScoresTotal/allOnsiteStudents.Count();

            return averageExamScoreOfAllOnsiteStudents;
        }

        private static IEnumerable<Student> ExtractStudentsWithoutHomeworkSent(List<Student> students)
        {
            IEnumerable<Student> allStudentsWithoutHomeworkSent =
                from student in students
                where student.HomeworksSent == 0
                orderby student.FirstName, student.LastName
                select student;

            return allStudentsWithoutHomeworkSent;
        }

        private static IEnumerable<Student> ExtractFirstNameStartsWithA(List<Student> students)
        {
            IEnumerable<Student> allStudentsFirstNameStartsWithA =
                from student in students
                where student.FirstName[0] == 'A'
                select student;

            return allStudentsFirstNameStartsWithA;
        }

        private static void PrintQueryResult<T>(IEnumerable<T> queryResults)
        {
            foreach (var item in queryResults)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<Student> ExtractAllMaleStudents(List<Student> students)
        {
            IEnumerable<Student> allMaleStudents =
                from student in students
                where student.Gender == "Male"
                select student;

            return allMaleStudents;
        }

        private static List<string> ReadFileLines(string filename, bool hasHeader)
        {
            var allLines = new List<string>();
            var reader = new StreamReader(filename);
            using (reader)
            {
                string currentLine;
                if (hasHeader)
                {
                    currentLine = reader.ReadLine();
                }

                currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    allLines.Add(currentLine);
                    currentLine = reader.ReadLine();
                }
            }

            return allLines;
        }

        private static bool CheckFileForHeaderExistence(string file)
        {
            StreamReader reader = new StreamReader(file);
            bool hasHeader = true;
            using (reader)
            {
                string line = reader.ReadLine();
                string[] lineArray = line.Split(' ').ToArray();
                int num = 0;
                bool isFirstWordNumber = int.TryParse(lineArray[0], out num);
                if (isFirstWordNumber)
                {
                    hasHeader = false;
                }
            }

            return hasHeader;
        }

        private static void CreateStudentsFromFileInfo(List<Student> students, List<string> fileLines)
        {
            foreach (string fileLine in fileLines)
            {
                string[] tokens = fileLine.Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                int id = int.Parse(tokens[0]);
                string firstName = tokens[1];
                string lastName = tokens[2];
                string email = tokens[3];
                string gender = tokens[4];
                string studentType = tokens[5];
                int examResult = int.Parse(tokens[6]);
                int homeworksSent = int.Parse(tokens[7]);
                int homeworksEvaluated = int.Parse(tokens[8]);
                double teamworkScore = double.Parse(tokens[9]);
                int attendancesCount = int.Parse(tokens[10]);
                double bonus = double.Parse(tokens[11]);

                students.Add(new Student(
                    id,
                    firstName,
                    lastName,
                    email,
                    gender,
                    studentType,
                    examResult,
                    homeworksSent,
                    homeworksEvaluated,
                    teamworkScore,
                    attendancesCount,
                    bonus));
            }
        }
    }
}
