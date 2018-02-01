using System;
using System.Linq;

public class SumWithUnlimitedAmountOfCoins
{
    public static void Main()
    {
        string[] s = Console.ReadLine().Split();
        int sum = int.Parse(s[2]);
        string[] numbers = Console.ReadLine().Split();
        numbers[2] = numbers[2].Trim(new char[] { '{', '}' });
        int[] coins = numbers[2].Split(',').Select(int.Parse).ToArray();

        Console.WriteLine(FindCombimations(sum, coins));
    }

    public static int FindCombimations(int sum, int[] coins)
    {
        if (sum < 0)
        {
            return 0;
        }

        if (coins == null || coins.Length == 0)
        {
            return 0;
        }

        int[] numberOfCombinations = new int[sum + 1];
        numberOfCombinations[0] = 1;
        for (int i = 0; i < coins.Length; ++i)
        {
            for (int j = coins[i]; j <= sum; ++j)
            {
                numberOfCombinations[j] += numberOfCombinations[j - coins[i]];
            }
        }

        return numberOfCombinations[sum];
    }
}

