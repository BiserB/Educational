
using System;

public class Hen : Bird
{
    public Hen(string name, double weight, double wing)
    {
        Name = name;
        Weight = weight;
        WingSize = wing;
    }

    public override bool Eat(Food food)
    {        
        Weight += food.Quantity * 0.35;
        FoodEaten += food.Quantity;
        return true;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }
}
