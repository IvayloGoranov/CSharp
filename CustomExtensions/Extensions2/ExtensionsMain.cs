﻿using System.Collections.Generic;
using System;

namespace Extensions
{
    class ExtensionsMain
    {
        static void Main()
        {
            List<int> collection = new List<int>() { 1, 2, 3, 4, 6, 11, 3 };

            Console.WriteLine(collection.FirstOrDefault(x => x > 7));
            Console.WriteLine(collection.FirstOrDefault(x => x < 0));

            Console.WriteLine(string.Join(", ", collection.TakeWhile(x => x < 10)));

            collection.ForEach(Console.WriteLine);
        }
    }
}
