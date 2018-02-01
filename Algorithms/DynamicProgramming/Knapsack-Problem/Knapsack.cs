namespace Knapsack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Knapsack
    {
        public static void Main()
        {
            var items = new[]
            {
                new Item { Weight = 5, Price = 30 },
                new Item { Weight = 8, Price = 120 },
                new Item { Weight = 7, Price = 10 },
                new Item { Weight = 0, Price = 20 },
                new Item { Weight = 4, Price = 50 },
                new Item { Weight = 5, Price = 80 },
                new Item { Weight = 2, Price = 10 }
            };

            int knapsackCapacity = 20;

            Item[] itemsTaken = FillKnapsack(items, knapsackCapacity);

            Console.WriteLine("Knapsack weight capacity: {0}", knapsackCapacity);
            Console.WriteLine("Take the following items in the knapsack:");
            foreach (var item in itemsTaken)
            {
                Console.WriteLine("  (weight: {0}, price: {1})", item.Weight, item.Price);
            }

            Console.WriteLine("Total weight: {0}", itemsTaken.Sum(i => i.Weight));
            Console.WriteLine("Total price: {0}", itemsTaken.Sum(i => i.Price));
        }

        public static Item[] FillKnapsack(Item[] items, int capacity)
        {
            int[,] maxPrice = new int[items.Length, capacity + 1];
            bool[,] isItemTaken = new bool[items.Length, capacity + 1];

            //Calculate maxPrice[0, 0..capacity]
            for (int c = 0; c <= capacity; c++)
            {
                if (items[0].Weight <= c)
                {
                    maxPrice[0, c] = items[0].Price;
                    isItemTaken[0, c] = true;
                }
            }

            //Calculate maxPrice[1 ...items.Length, 0...capacity]
            for (int i = 1; i < items.Length; i++)
            {
                for (int c = 0; c <= capacity; c++)
                {
                    //Don't take item i.
                    maxPrice[i, c] = maxPrice[i - 1, c];
                    int remainingCapacity = c - items[i].Weight;
                    if (remainingCapacity >= 0 &&
                        maxPrice[i - 1, remainingCapacity] + items[i].Price > maxPrice[i - 1, c])
                    {
                        maxPrice[i, c] = maxPrice[i - 1, remainingCapacity] + items[i].Price;
                        isItemTaken[i, c] = true;
                    }
                }
            }

            //Retrieve the items taken.
            List<Item> itemsTaken = new List<Item>();
            int itemIndex = items.Length - 1;

            while (itemIndex >= 0)
            {
                if (isItemTaken[itemIndex, capacity])
                {
                    itemsTaken.Add(items[itemIndex]);
                    capacity = capacity - items[itemIndex].Weight;
                }

                itemIndex--;
            }

            itemsTaken.Reverse();

            return itemsTaken.ToArray();
        }
    }
}
