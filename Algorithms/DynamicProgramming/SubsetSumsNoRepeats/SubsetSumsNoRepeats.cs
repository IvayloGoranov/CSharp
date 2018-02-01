using System;
using System.Collections.Generic;

class SubsetSumsNoRepeats
{
    static void Main(string[] args)
    {
        int[] nums = { 3, 5, -1, 10, 5, 7 };
        int targetSum = 19;

        var possibleSums = CalcPossibleSums(nums, targetSum);

        // Print subset
        if (possibleSums.ContainsKey(targetSum))
        {
            var subset = FindSubset(nums, targetSum, possibleSums);
            Console.Write(targetSum + " = ");
            Console.WriteLine(String.Join(" + ", subset));
        }
        else
        {
            Console.WriteLine("Not possible sum: {0}", targetSum);
        }
    }

    private static IDictionary<int, int> CalcPossibleSums(
        int[] nums, int targetSum)
    {
        var possibleSums = new Dictionary<int, int>();
        possibleSums.Add(0, 0);
        for (int i = 0; i < nums.Length; i++)
        {
            var newSums = new Dictionary<int, int>();
            foreach (var sum in possibleSums.Keys)
            {
                int newSum = sum + nums[i];
                if (!possibleSums.ContainsKey(newSum))
                {
                    newSums.Add(newSum, nums[i]);
                }
            }

            foreach (var sum in newSums)
            {
                possibleSums.Add(sum.Key, sum.Value);
            }
        }

        return possibleSums;
    }

    private static IEnumerable<int> FindSubset(
        int[] nums, int targetSum, IDictionary<int, int> possibleSums)
    {
        var subset = new List<int>();
        while (targetSum > 0)
        {
            var lastNum = possibleSums[targetSum];
            subset.Add(lastNum);
            targetSum -= lastNum;
        }

        subset.Reverse();
        return subset;
    }
}
