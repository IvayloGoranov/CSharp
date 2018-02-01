using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GroupPermutations
{
    public static void Main()
    {
        string input = Console.ReadLine();
        char[] array = input.ToCharArray();

        bool containsDistinct = array.Distinct().Count() == array.Length;
        if (containsDistinct)
        {
            GeneratePermutations(array, 0);
        }
        else
        {
            var grouped = array.GroupBy(a => a);
            string[] arrayWithReps = new string[grouped.Count()];
            int index = 0;
            foreach (var group in grouped)
            {
                arrayWithReps[index] = new string(group.Key, group.Count());
                index++;
            }

            GeneratePermutations(arrayWithReps, 0);
        }
    }

    private static void GeneratePermutations<T>(T[] arr, int k)
    {
        if (k >= arr.Length)
        {
            Print(arr);
        }
        else
        {
            GeneratePermutations(arr, k + 1);
            for (int i = k + 1; i < arr.Length; i++)
            {
                Swap(ref arr[k], ref arr[i]);
                GeneratePermutations(arr, k + 1);
                Swap(ref arr[k], ref arr[i]);
            }
        }
    }

    private static void Print<T>(T[] arr)
    {
        Console.WriteLine(string.Join("", arr));
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}