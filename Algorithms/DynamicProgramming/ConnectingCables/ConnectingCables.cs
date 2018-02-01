using System;
using System.Linq;
using System.Collections.Generic;

public class ConnectingCables
{
    static void Main()
    {
        string[] sideOneArgs = Console.ReadLine().Split();
        int[] sideOne = sideOneArgs[2].Trim(new char[] { '{', '}' }).Split(',').Select(int.Parse).ToArray();
        string[] sideTwoArgs = Console.ReadLine().Split();
        int[] sideTwo = sideTwoArgs[2].Trim(new char[] { '{', '}' }).Split(',').Select(int.Parse).ToArray();

        var connectionCables = FindConnectedCables(sideOne, sideTwo);

        Console.WriteLine("Maximum pairs connected: " + connectionCables.Length);
        Console.WriteLine("Connected pairs: " + string.Join(" ", connectionCables));
    }

    private static int[] FindConnectedCables(int[] sideOne, int[] sideTwo)
    {
        int firstLen = sideOne.Length + 1;
        int secondLen = sideTwo.Length + 1;
        var connecting = new int[firstLen, secondLen];

        for (int i = 1; i < firstLen; i++)
        {
            for (int j = 1; j < secondLen; j++)
            {
                if (sideOne[i - 1] == sideTwo[j - 1])
                {
                    connecting[i, j] = connecting[i - 1, j - 1] + 1;
                }
                else
                {
                    connecting[i, j] = Math.Max(connecting[i - 1, j], connecting[i, j - 1]);
                }
            }
        }

        var cables = new List<int>();
        for (int x = connecting.GetUpperBound(0); x >= 0; x--)
        {
            for (int y = connecting.GetUpperBound(1); y >= 0; y--)
            {
                while (x > 0 && y > 0)
                {
                    if (sideOne[x - 1] == sideTwo[y - 1])
                    {
                        cables.Add(sideOne[x - 1]);
                        x--;
                        y--;
                    }
                    else if (connecting[x, y] == connecting[x - 1, y])
                    {
                        x--;
                    }
                    else
                    {
                        y--;
                    }
                }
            }
        }

        cables.Reverse();

        return cables.ToArray();
    }
}
