using System;


public class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        decimal pricePerDay = decimal.Parse(input[0]);
        int numberOfDays = int.Parse(input[1]);
        string season = input[2];
        string discount = "";
        if (input.Length == 4)
        {
            discount = input[3];
        }        

        decimal result = PriceCalculator.Calculate(pricePerDay, numberOfDays, season, discount);

        Console.WriteLine($"{result:f2}");
    }
}
