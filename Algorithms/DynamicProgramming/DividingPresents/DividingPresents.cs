using System;
using System.Collections.Generic;
using System.Linq;

public class DividingPresents
{
    private static List<int> allSums = new List<int>();
    private static Dictionary<int, int> presentsSums = new Dictionary<int, int> { { 0, 0 } };

    public static void Main()
    {
        int[] presents = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        CalculatePresentsSums(presents);

        int presentsHalfSum = presents.Sum() / 2;
        int sumAlan = 0;
        if (!presentsSums.ContainsKey(presentsHalfSum))
        {
            allSums.Add(presentsHalfSum);
            allSums.Sort();
            sumAlan = allSums[allSums.IndexOf(presentsHalfSum) - 1];
        }
        else
        {
            sumAlan = presentsHalfSum;
        }

        IEnumerable<int> presentsAlan = FindAlanPresents(sumAlan);
        Console.WriteLine("Difference: {0}", Math.Abs(presents.Sum() - (2 * presentsAlan.Sum())));
        Console.WriteLine("Alan:{0} Bob:{1}", presentsAlan.Sum(), presents.Sum() - presentsAlan.Sum());
        Console.WriteLine("Alan takes: {0}", string.Join(" ", presentsAlan));
        Console.WriteLine("Bob takes the rest.");
    }

    private static void CalculatePresentsSums(int[] nums)
    {
        presentsSums = new Dictionary<int, int> { { 0, 0 } };

        for (int i = 0; i < nums.Length; i++)
        {
            Dictionary<int, int> newSums = new Dictionary<int, int>();
            foreach (var sum in presentsSums.Keys)
            {
                int newSum = sum + nums[i];
                if (!presentsSums.ContainsKey(newSum))
                {
                    newSums.Add(newSum, nums[i]);
                }
            }

            foreach (var sum in newSums)
            {
                presentsSums.Add(sum.Key, sum.Value);
                allSums.Add(sum.Key);
            }
        }
    }

    private static IEnumerable<int> FindAlanPresents(int targetSum)
    {
        List<int> presentsAlan = new List<int>();
        while (targetSum > 0)
        {
            int lastNum = presentsSums[targetSum];
            presentsAlan.Add(lastNum);
            targetSum -= lastNum;
        }

        return presentsAlan;
    }
}
