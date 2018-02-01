namespace Problem_2.Processor_Scheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProcessScheduling
    {
        public static void Main(string[] args)
        {
            var numberOfTasks = int.Parse(Console.ReadLine().Split().ToArray()[1]);
            var tasks = new List<int[]>();
            var deadline = 0;
            for (int i = 0; i < numberOfTasks; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (input[1] > deadline)
                {
                    deadline = input[1];
                }

                tasks.Add(input);
            }

            var priorityTasks = tasks.OrderByDescending(t => t[0]).ToList();

            var totalValue = 0;
            var result = new List<int[]>();
            for (int i = 1; i <= deadline; i++)
            {
                var possibleTaskMax = priorityTasks.OrderByDescending(t => t[0]).ThenBy(t => t[1]).First();

                if (possibleTaskMax != null)
                {
                    totalValue += possibleTaskMax[0];
                    result.Add(possibleTaskMax);

                    priorityTasks.Remove(possibleTaskMax);
                }
            }

            var sortedResult = result.OrderBy(t => t[1]).ThenByDescending(t => t[0]).ToList();
            var indicesResult = new List<int>();
            foreach (var pair in sortedResult)
            {
                var index = tasks.IndexOf(pair);
                indicesResult.Add(index + 1);
            }

            Console.WriteLine("Optimal schedule:  {0}", string.Join(" -> ", indicesResult));
            Console.WriteLine("Total value: {0}", totalValue);
        }
    }
}