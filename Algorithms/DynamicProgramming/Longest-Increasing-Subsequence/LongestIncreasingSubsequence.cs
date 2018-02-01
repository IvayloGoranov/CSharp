using System;
using System.Collections.Generic;
using System.Linq;

public class LongestIncreasingSubsequence
{
    public static void Main()
    {
        var sequence = new int[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
        var longestSeq = FindLongestIncreasingSubsequence(sequence);
        Console.WriteLine("Longest increasing subsequence (LIS)");
        Console.WriteLine("  Length: {0}", longestSeq.Length);
        Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
    }

    public static int[] FindLongestIncreasingSubsequence(int[] sequence)
    {
        int[] lisLengths = new int[sequence.Length];
        int[] previous = new int[sequence.Length];
        int maxLength = 0;
        int lastIndex = -1;

        for (int x = 0; x < sequence.Length; x++)
        {
            lisLengths[x] = 1;
            previous[x] = -1;

            for (int i = 0; i < x; i++)
            {
                if ((sequence[i] < sequence[x]) && (lisLengths[i] + 1 > lisLengths[x]))
                {
                    lisLengths[x] = lisLengths[i] + 1;
                    previous[x] = i;
                }
            }

            if (lisLengths[x] > maxLength)
            {
                maxLength = lisLengths[x];
                lastIndex = x;
            }
        }

        int[] longestLIS = RestoreLIS(sequence, previous, lastIndex);

        return longestLIS;
    }

    private static int[] RestoreLIS(int[] sequence, int[] previous, int lastIndex)
    {
        var longestLIS = new List<int>();
        while (lastIndex != -1)
        {
            longestLIS.Add(sequence[lastIndex]);
            lastIndex = previous[lastIndex];
        }

        longestLIS.Reverse();

        return longestLIS.ToArray();
    }
}
