
using System;

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