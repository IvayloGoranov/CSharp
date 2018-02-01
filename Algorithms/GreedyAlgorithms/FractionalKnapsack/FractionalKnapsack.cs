using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class P1FractionalKnapsack
{
    public static void Main()
    {
        var items = new[]                       //Hardcoded values, example 1 from the problem condition.
                                                //Works well with the values from this example and the other 2 example values.
        {
            new {Price = 25, Weight = 10},
            new {Price = 12, Weight = 8},
            new {Price = 16, Weight = 8},
        };

        int knapsackCapacity = 16; //In terms of weight.
        //var items = new[]                       //Hardcoded values, example 4 from the problem condition.
        //{                                       //Doesn't show the results from the example output. 
        //    new {Price = 12, Weight = 14},      //The output results in this problem example do not coincide with the classical  
        //    new {Price = 45, Weight = 54},      //knapsack problem - to pick the items with highest price value.  
        //    new {Price = 98, Weight = 78},
        //    new {Price = 21, Weight = 51},
        //    new {Price = 64, Weight = 11},
        //    new {Price = 90, Weight = 117},
        //    new {Price = 33, Weight = 17},
        //    new {Price = 64, Weight = 23},
        //    new {Price = 7, Weight = 3}
        //};
        //int knapsackCapacity = 134; //In terms of weight.
        Array.Sort(items, (a, b) => a.Price.CompareTo(b.Price)); //Sorting the items as per price.
        Array.Reverse(items);
        //A dictionary with key Tuple<int, int> representing price and weight respectively and value - quantity
        //of the item taken.
        Dictionary<Tuple<int, int>, double> selectedItems = new Dictionary<Tuple<int, int>, double>();
        int currentSum = 0;
        foreach (var item in items)
        {
            int remainingSum = knapsackCapacity - currentSum; //Calculating current capacity left.
            double quantityToTake = remainingSum / (double)item.Weight; //Calculating quantity of the item to take.
            if (quantityToTake > 1) //If bigger than 1, then take 100%, the whole quantity, the whole weight.
            {
                selectedItems.Add(new Tuple<int, int>(item.Price, item.Weight), remainingSum / item.Weight);
                currentSum = currentSum + item.Weight; //Adding the whole weight of the item.
            }
            else //If less than 1, then we do not have enough capacity and should take a fraction of the item's weight.
            {
                selectedItems.Add(new Tuple<int, int>(item.Price, item.Weight), quantityToTake);
                currentSum = currentSum + (int)(item.Weight * quantityToTake); //Adding the fraction of the item's weight.
            }

            if (currentSum == knapsackCapacity)
            {
                break; //Break the loop if capacity is reached, i.e. we do not take all of the items.
            }
        }

        double currentPriceSum = 0;
        foreach (var item in selectedItems)
        {
            Console.WriteLine("Take {0}% of item with price {1:0.00} and weight {2:0.00}", item.Value * 100, item.Key.Item1,
                item.Key.Item2); //Value in the dictionary is the fraction of the item taken;
            //key is the pair price-weight, which is a Tuple, hence accessed by Item1 and Item2 of the Tuple properties.
            currentPriceSum = currentPriceSum + item.Key.Item1 * item.Value;
        }

        Console.WriteLine("Total price {0:0.00}", currentPriceSum);
    }
}
