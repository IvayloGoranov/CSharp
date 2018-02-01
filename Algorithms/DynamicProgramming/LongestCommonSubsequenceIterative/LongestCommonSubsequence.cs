using System;
using System.Collections.Generic;

public class LongestCommonSubsequence
{
    public static void Main()
    {
        var firstStr = "tree";
        var secondStr = "team";

        var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

        Console.WriteLine("Longest common subsequence:");
        Console.WriteLine("  first  = {0}", firstStr);
        Console.WriteLine("  second = {0}", secondStr);
        Console.WriteLine("  lcs    = {0}", lcs);
    }

    public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
    {
        int[,] memo = new int[firstStr.Length + 1, secondStr.Length + 1];
        for (int first = 1; first < firstStr.Length + 1; first++)
        {
            for (int second = 1; second < secondStr.Length + 1; second++)
            {
                if (firstStr[first - 1] == secondStr[second - 1])
                {
                    memo[first, second] = memo[first - 1, second - 1] + 1;
                }
                else
                {
                    memo[first, second] = Math.Max(memo[first - 1, second],  memo[first, second - 1]);
                }
            }
        }

        string lcs = RetrieveLCS(firstStr, secondStr, memo);

        return lcs;
    }

    static string RetrieveLCS(string firstStr, string secondStr, int[,] lcsValues)
    {
        int row = lcsValues.GetLength(0) - 1;
        int col = lcsValues.GetLength(1) - 1;
        List<char> result = new List<char>();
        while (row > 0 && col > 0)
        {
            if (firstStr[row - 1] == secondStr[col - 1])
            {
                result.Add(firstStr[row]);
                row--;
                col--;
            }
            else if (lcsValues[row, col] == lcsValues[row - 1, col])
            {
                row--;
            }
            else
            {
                col--;
            }
        }

        result.Reverse();

        return new string(result.ToArray());
    }
}
