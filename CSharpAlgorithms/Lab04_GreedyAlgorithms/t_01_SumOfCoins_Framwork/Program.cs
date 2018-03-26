
using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        Dictionary<int, int> selectedCoins = new Dictionary<int, int>();

        try
        {
            selectedCoins = ChooseCoins(availableCoins, targetSum);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");

        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        coins = coins.OrderByDescending(c => c).ToList();

        int sum = 0;

        Dictionary<int, int> selected = new Dictionary<int, int>(); // coin - amount

        for (int i = 0; i < coins.Count; i++)
        {
            int coin = coins[i];

            int remaining = targetSum - sum;

            int amount = remaining / coin;

            if (amount == 0)
            {
                continue;
            }

            sum += coin * amount;

            selected[coin] = amount;

            if (sum == targetSum)
            {
                break;
            }
        }
        if (sum != targetSum)
        {
            throw new InvalidOperationException("Error");
        }

        return selected;
    }
}