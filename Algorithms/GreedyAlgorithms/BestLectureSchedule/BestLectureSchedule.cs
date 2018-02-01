namespace Problem_4.Best_Lectures_Schedule
{
    using System;
    using System.Collections.Generic;

    public class LectureSchedule
    {
        private static Lecture[] lectures;
        private static List<Lecture> schedule;

        public static void Main()
        {
            ReadInput();
            FindBestLecturesSchedule();
            PrintBestLecturesSchedule();
        }

        private static void ReadInput()
        {
            string[] lecturesCount = Console.ReadLine().Split();
            int n = int.Parse(lecturesCount[1]);
            lectures = new Lecture[n];

            for (int i = 0; i < n; i++)
            {
                string[] currentLecture = Console.ReadLine()
                    .Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

                lectures[i] = new Lecture(
                    currentLecture[0],
                    int.Parse(currentLecture[1]),
                    int.Parse(currentLecture[2]));
            }
        }

        private static void FindBestLecturesSchedule()
        {
            Array.Sort(lectures);
            Lecture lastSelectedLecture = lectures[0];
            schedule = new List<Lecture>();
            schedule.Add(lastSelectedLecture);
            foreach (Lecture lecture in lectures)
            {
                if (lecture.Start >= lastSelectedLecture.End)
                {
                    schedule.Add(lecture);
                    lastSelectedLecture = lecture;
                }
            }
        }

        private static void PrintBestLecturesSchedule()
        {
            Console.WriteLine();
            Console.WriteLine("Lectures ({0}):", schedule.Count);
            foreach (Lecture lecture in schedule)
            {
                Console.WriteLine(lecture);
            }
        }
    }
}
