using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ShortestPath
{
    private static int[] combsArray;

    private static string[] directions = new string[] { "L", "R", "S" };

    private static List<char> visibleDirections = new List<char>();

    private static int starsCount = 0;

    private static int possibleDirectionsCount = 0;

    private static string path;

    private static StringBuilder result = new StringBuilder();

    public static void Main()
    {
        path = Console.ReadLine();
        for (int i = 0; i < path.Length; i++)
        {
            if (path[i].Equals('*'))
            {
                starsCount++;
            }
            else
            {
                visibleDirections.Add(path[i]);
            }
        }

        combsArray = new int[starsCount];

        GenerateVariationsWithRepetitions(0);

        Console.WriteLine(possibleDirectionsCount);
        result.Length = result.Length - 1;
        Console.WriteLine(result);
    }

    private static void GenerateVariationsWithRepetitions(int index)
    {
        if (index >= starsCount)
        {
            PrintVariations();
        }
        else
        {
            for (int i = 0; i < directions.Length; i++)
            {
                combsArray[index] = i;
                GenerateVariationsWithRepetitions(index + 1);
            }
        }
    }

    private static void PrintVariations()
    {
        string currentPossibleDirection = string.Join("", combsArray.Select(i => directions[i]));
        char[] possibleDirections = new char[visibleDirections.Count + starsCount];
        int guessedDirectionIndex = 0;
        int visibleDirectionIndex = 0;
        for (int i = 0; i < possibleDirections.Length; i++)
        {
            if (path[i].Equals('*'))
            {
                possibleDirections[i] = currentPossibleDirection[guessedDirectionIndex];
                guessedDirectionIndex++;
            }
            else
            {
                possibleDirections[i] = visibleDirections[visibleDirectionIndex];
                visibleDirectionIndex++;
            }
        }

        possibleDirectionsCount++;
        result.Append(possibleDirections);
        result.Append(Environment.NewLine);
    }
}
