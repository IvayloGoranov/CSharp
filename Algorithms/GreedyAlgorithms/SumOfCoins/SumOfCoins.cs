namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine("Number of coins to take: {0}", selectedCoins.Values.Sum());
            
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine("{0} coin(s) with value {1}", selectedCoin.Value, selectedCoin.Key);
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var sortedCoins = coins.OrderByDescending(c => c).ToList();
            var chosenCoins = new Dictionary<int, int>();
            int currentSum = 0;
            int currentCoinIndex = 0;

            while (currentSum != targetSum && currentCoinIndex < sortedCoins.Count)
            {
                int currentCoinValue = sortedCoins[currentCoinIndex];
                int remainingSum = targetSum - currentSum;
                int numberOfCoinsToTake = remainingSum / currentCoinValue;

                if (numberOfCoinsToTake > 0)
                {
                    chosenCoins.Add(currentCoinValue, numberOfCoinsToTake);
                    currentSum = currentSum + (currentCoinValue * numberOfCoinsToTake);
                }

                currentCoinIndex++;
            }

            if (targetSum != currentSum)
            {
                throw new InvalidOperationException
                    ("Greedy algorithm cannot produce desired sum with specified coins");
            }

            return chosenCoins;
        }
    }
}