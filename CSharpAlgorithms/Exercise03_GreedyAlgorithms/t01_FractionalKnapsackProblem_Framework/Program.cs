using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        List<Item> items = new List<Item>();
        double totalPrice = 0;

        string[] input = Console.ReadLine().Split();
        double capacity = double.Parse(input[1]);

        input = Console.ReadLine().Split();
        double itemsCount = double.Parse(input[1]);

        for (int i = 0; i < itemsCount; i++)
        {
            input = Console.ReadLine().Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
            double price = double.Parse(input[0]);
            double weight = double.Parse(input[1]);

            Item item = new Item(price, weight);

            items.Add(item);
        }

        items.Sort();

        for (int i = items.Count - 1; i >= 0; i--)
        {
            if (capacity == 0)
            {
                break;
            }

            Item item = items[i];
            double percent = 100;

            if (capacity >= item.Weight)
            {
                capacity -= item.Weight;
                totalPrice += item.Price;
                Console.WriteLine($"Take 100% of item with price {item.Price:f2} and weight {item.Weight:f2}");
            }
            else
            {
                percent = Math.Round(((capacity / item.Weight) * 100), 2);
                totalPrice += (item.Price * percent / 100);
                capacity = 0;
                Console.WriteLine($"Take {percent:f2}% of item with price {item.Price:f2} and weight {item.Weight:f2}");
            }

        }

        Console.WriteLine($"Total price: {totalPrice:f2}");

    }
}

public class Item : IComparable<Item>
{
    public Item(double price, double weight)
    {
        Price = price;
        Weight = weight;
        Rating = price / weight;
    }

    public double Price { get; }
    public double Weight { get; }
    public double Rating { get; }

    public int CompareTo(Item other)
    {
        int result = this.Rating.CompareTo(other.Rating);

        return result;
    }

    public override string ToString()
    {
        return $"{Price} - {Weight}";
    }
}