using System;
using System.Collections.Generic;

class SubsetSumsWithRepeats
{
    static void Main(string[] args)
    {
        int[] nums = { 2, 5, 10 };
        int targetSum = 50;

        var possibleSums = CalcPossibleSums(nums, targetSum);

        // Print subset
        if (possibleSums[targetSum])
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

    private static bool[] CalcPossibleSums(int[] nums, int targetSum)
    {
        var possible = new bool[targetSum + 1];
        possible[0] = true;
        for (int sum = 0; sum < possible.Length; sum++)
        {
            if (possible[sum])
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    int newSum = sum + nums[i];
                    if (newSum <= targetSum)
                    {
                        possible[newSum] = true;
                    }
                }
            }
        }

        return possible;
    }

    private static IEnumerable<int> FindSubset(
        int[] nums, int targetSum, bool[] possibleSums)
    {
        var subset = new List<int>();
        while (targetSum > 0)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int newSum = targetSum - nums[i];
                if (newSum >= 0 && possibleSums[newSum])
                {
                    targetSum = newSum;
                    subset.Add(nums[i]);
                }
            }
        }

        return subset;
    }
}
