using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class P3GenericListTest
{
    static void Main()
    {
        GenericList<int> intList = new GenericList<int>();
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        foreach (int num in intList)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine("Number of elements: {0}", intList.Count);
        intList.Remove(3);
        foreach (int num in intList)
        {
            Console.WriteLine(num);
        }
        intList.RemoveAt(2);
        Console.WriteLine("Number of elements: {0}", intList.Count);
        foreach (int num in intList)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine("Max element: {0}", intList.Max());
        Console.WriteLine("Min element: {0}", intList.Min());
        int element = 1;
        Console.WriteLine("Index of element {0} is {1}", element, intList.IndexOf(element));
        intList.InsertAt(28, 1);
        Console.WriteLine(string.Join(", ", intList));
        Console.WriteLine(intList.Contains(28));
        Console.WriteLine(intList.Contains(100));
        Console.WriteLine(intList);
        intList.Clear();
        Console.WriteLine(intList);
    }
}
