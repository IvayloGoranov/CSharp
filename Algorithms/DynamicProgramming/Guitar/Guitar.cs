using System;
using System.Linq;

public class Guitar
{
    public static void Main(string[] args)
    {
        int[] intervals = Console.ReadLine().
            Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).
            Select(int.Parse).ToArray();
        int startVolume = int.Parse(Console.ReadLine());
        int maxVolume = int.Parse(Console.ReadLine());

        int bestVolume = DetermineBestVoulme(intervals, startVolume, maxVolume);

        Console.WriteLine(bestVolume);
    }

    private static int DetermineBestVoulme(int[] intervals, int beginVolume, int maxVolume)
    {
        int[,] bestVolumesAtEachInterval = new int[intervals.Length + 1, maxVolume + 1];
        bestVolumesAtEachInterval[0, beginVolume] = 1;
        for (int i = 1; i <= intervals.Length; i++)
        {
            for (int j = 0; j <= maxVolume; j++)
            {
                if (bestVolumesAtEachInterval[i - 1, j] == 1)
                {
                    int x = intervals[i - 1];
                    if (j - x >= 0)
                    {
                        bestVolumesAtEachInterval[i, j - x] = 1;
                    }

                    if (j + x <= maxVolume)
                    {
                        bestVolumesAtEachInterval[i, j + x] = 1;
                    }
                }
            }
        }

        for (int i = maxVolume; i >= 0; i--)
        {
            if (bestVolumesAtEachInterval[intervals.Length, i] == 1)
            {
                return i;
            }
        }

        return -1;
    }
}
