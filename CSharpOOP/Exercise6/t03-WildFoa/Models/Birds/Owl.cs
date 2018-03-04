
using System;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize)
    {
        Name = name;
        Weight = weight;
        WingSize = wingSize;
    }

    public override bool Eat(Food food)
    {
        if (food.Type != "Meat")
        {
            return false;
        }
        Weight += food.Quantity * 0.25;
        FoodEaten += food.Quantity;
        return true;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Hoot Hoot");
    }
}
