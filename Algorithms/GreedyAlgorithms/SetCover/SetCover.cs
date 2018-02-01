namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetCover
    {
        public static void Main(string[] args)
        {
            int[] universe = new int[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            List<int[]> sets = new List<int[]>()
            {
                new int[] { 20 },
                new int[] { 1, 5, 20, 30 },
                new int[] { 3, 7, 20, 30, 40 },
                new int[] { 9, 30 },
                new int[] { 11, 20, 30, 40 },
                new int[] { 3, 7, 40 }
            };

            var selectedSets = ChooseSets(sets, universe.ToList());
            Console.WriteLine("Sets to take ({0}):", selectedSets.Count);
            foreach (var set in selectedSets)
            {
                Console.WriteLine("{{{0}}}", string.Join(", ", set));
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                var currentSet = sets.OrderByDescending(set => set.Count(universe.Contains)).FirstOrDefault();
                if (currentSet != null)
                {
                    selectedSets.Add(currentSet);
                    sets.Remove(currentSet);
                    foreach (int number in currentSet)
                    {
                        universe.Remove(number);
                    }
                }
            }

            return selectedSets;
        }
    }
}
