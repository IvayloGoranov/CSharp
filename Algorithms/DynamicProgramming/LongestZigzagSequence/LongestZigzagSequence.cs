using System;
using System.Linq;
using System.Collections.Generic;

public class LongestZigzagSubsequence
{
    static void Main(string[] args)
    {
        int[] sequence = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
        int[] longestZS = FindLongestZigZagSubsequence(sequence);
        Console.WriteLine(string.Join(" ", longestZS));
    }

    public static int[] FindLongestZigZagSubsequence(int[] sequence)
    {
        if (sequence.Length == 1)
        {
            return sequence;
        }

        int[] lzsLengths = new int[sequence.Length];
        lzsLengths[0] = 1;
        int[] previous = new int[sequence.Length];
        int lastIndex = -1;
        previous[0] = lastIndex;
        bool evenIsSmaller = sequence[0] < sequence[1];

        for (int i = 1; i < sequence.Length; i++)
        {
            if ((sequence[i - 1] < sequence[i] && evenIsSmaller) || (sequence[i - 1] > sequence[i] && !evenIsSmaller))
            {
                lzsLengths[i] = lzsLengths[i - 1] + 1;
                previous[i] = i - 1;
                lastIndex = i;
                evenIsSmaller = !evenIsSmaller;
            }
            else
            {
                lzsLengths[i] = lzsLengths[i - 1];
                previous[i] = previous[i - 1];
            }
        }

        List<int> longestZigZagSeq = new List<int>();
        while (lastIndex != -1)
        {
            longestZigZagSeq.Add(sequence[lastIndex]);
            lastIndex = previous[lastIndex];
        }

        longestZigZagSeq.Reverse();

        return longestZigZagSeq.ToArray();
    }
}
