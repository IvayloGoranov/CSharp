using System;
using System.Linq;
using System.Collections.Generic;

public class MinimumEditDistance
{
    private static int[,] distances;

    public static void Main()
    {
        string[] firstOperation = Console.ReadLine().Split('=').ToArray();
        string[] secondOperation = Console.ReadLine().Split('=').ToArray();
        string[] thirdOperation = Console.ReadLine().Split('=').ToArray();

        var operations = new[]
            {
                new Operation() {Name = "Replace", Cost = int.Parse(firstOperation[1])},
                new Operation() {Name = "Insert", Cost = int.Parse(secondOperation[1])},
                new Operation() {Name = "Delete", Cost = int.Parse(thirdOperation[1])}
            };

        string[] sideOne = Console.ReadLine().Split('=').ToArray();
        string s1 = sideOne[1].Trim();
        string[] sideTwo = Console.ReadLine().Split('=').ToArray();
        string s2 = sideTwo[1].Trim();

        distances = new int[s1.Length + 1, s2.Length + 1];
        for (int i = 1; i <= s1.Length; i++)
        {
            distances[i, 0] = operations[2].Cost * i;
        }
        for (int i = 1; i <= s2.Length; i++)
        {
            distances[0, i] = operations[1].Cost * i;
        }

        var distance = CalculateDistance(operations, s1, s2);
        Console.WriteLine("Minimum edit distance: " + distance);
        Changes(operations, s1, s2);
    }

    private static int CalculateDistance(Operation[] operations, string first, string second)
    {
        for (int i = 1; i < first.Length + 1; i++)
        {
            for (int j = 1; j < second.Length + 1; j++)
            {
                if (first[i - 1] == second[j - 1])
                {
                    distances[i, j] = distances[i - 1, j - 1];
                }
                else
                {
                    distances[i, j] = Math.Min(
                        Math.Min(distances[i - 1, j] + operations[2].Cost, distances[i, j - 1] + operations[1].Cost),
                        distances[i - 1, j - 1] + operations[0].Cost);
                }
            }
        }

        return distances[first.Length, second.Length];
    }

    private static void Changes(Operation[] operations, string s1, string s2)
    {
        List<string> list = new List<string>();
        int row = s1.Length;
        int col = s2.Length;

        while (row > 0 && col > 0)
        {
            int up = distances[row - 1, col];
            int left = distances[row, col - 1];
            int upLeft = distances[row - 1, col - 1];

            int min = Math.Min(Math.Min(up, left), upLeft);

            if (min == upLeft)
            {
                row--;
                col--;
                if (min < distances[row + 1, col + 1])
                {
                    if (operations[0].Cost <= operations[1].Cost + operations[2].Cost)
                    {
                        list.Add(string.Format("REPLACE({0},{1})", row, s2[col]));
                    }
                    else
                    {
                        list.Add(string.Format("INSERT({0},{1})", col, s2[col]));
                        list.Add(string.Format("DELETE({0})", row));
                    }
                }
            }
            else if (min == up)
            {
                row--;
                if (min < distances[row + 1, col])
                {
                    list.Add(string.Format("DELETE({0})", row));
                }
            }
            else
            {
                col--;
                if (min < distances[row, col + 1])
                {
                    list.Add(string.Format("INSERT({0},{1})", col, s2[col]));
                }
            }
        }

        while (row > 0)
        {
            int up = distances[row - 1, col];
            row--;
            if (up < distances[row + 1, col])
            {
                list.Add(string.Format("DELETE({0})", row));
            }
        }

        while (col > 0)
        {
            int left = distances[row, col - 1];
            col--;
            if (left < distances[row, col + 1])
            {
                list.Add(string.Format("INSERT({0},{1})", col, s2[col]));
            }
        }

        list.Reverse();

        Console.WriteLine(string.Join(Environment.NewLine, list));
    }
}
