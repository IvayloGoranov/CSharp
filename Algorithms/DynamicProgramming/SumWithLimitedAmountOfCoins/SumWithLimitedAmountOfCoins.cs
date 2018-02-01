using System;
using System.Linq;

public class SumWithLimitedAmountOfCoins
{
    public static void Main()
    {
        string[] s = Console.ReadLine().Split();
        int sum = int.Parse(s[2]);
        string[] numbers = Console.ReadLine().Split();
        numbers[2] = numbers[2].Trim(new char[] { '{', '}' });
        int[] coins = numbers[2].Split(',').Select(int.Parse).ToArray();
        Array.Sort(coins);
        Console.WriteLine(CalcPossibleSums(coins, sum));
    }

    private static int CalcPossibleSums(int[] nums, int targetSum)
    {
        bool[,] memo = new bool[nums.Length + 1, targetSum + 1];
        for (int row = 1; row < memo.GetLength(0); row++)
        {
            for (int col = 1; col < memo.GetLength(1); col++)
            {
                if (col - nums[row - 1] == 0)
                {
                    memo[row, col] = true;
                }
                else if (col - nums[row - 1] > 0)
                {
                    int remainder = col - nums[row - 1];
                    if (memo[row - 1, remainder])
                    {
                        memo[row, col] = true;
                    }
                }
                else
                {
                    memo[row, col] = memo[row - 1, col];
                }
            }
        }

        int countPossibleSums = 0;
        for (int row = memo.GetLength(0) - 1; row >= 0; row--)
        {
            if (memo[row, targetSum])
            {
                countPossibleSums++;
            }
        }

        return countPossibleSums;
    }
}
