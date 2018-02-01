using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Medenka
{
    static int[] medenka;
    static List<int> nutIndices = new List<int>();
    static List<int> cuts = new List<int>();
    static StringBuilder output = new StringBuilder();

    static void Main(string[] args)
    {
        medenka = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        for (int i = 0; i < medenka.Length; i++)
        {
            if (medenka[i] == 1)
            {
                nutIndices.Add(i);
            }
        }

        if (nutIndices.Count == 1)
        {
            Console.WriteLine(string.Join("", medenka));
        }
        else
        {
            GenerateMedenki(0);
            Console.Write(output);
        }
    }

    static void GenerateMedenki(int index)
    {
        if (index == nutIndices.Count - 1)
        {
            Print();
            return;
        }

        int currentNutIndex = nutIndices[index];
        int nextNutIndex = nutIndices[index + 1];
        // Perform cut on each index between two nuts
        for (int i = currentNutIndex; i < nextNutIndex; i++)
        {
            cuts.Add(i);
            GenerateMedenki(index + 1);
            cuts.RemoveAt(cuts.Count - 1);
        }
    }

    static void Print()
    {
        int currentCut = 0;
        for (int i = 0; i < cuts.Count; i++)
        {
            // Append all elements before cut
            for (int j = currentCut; j < cuts[i] + 1; j++)
            {
                output.Append(medenka[j]);
            }

            // Append cut
            output.Append('|');
            currentCut = cuts[i] + 1;
        }

        // Add all 0s and 1s after last cut
        var lastCut = cuts[cuts.Count - 1];
        for (int i = lastCut + 1; i < medenka.Length; i++)
        {
            output.Append(medenka[i]);
        }

        output.Append('\n');
    }
}
