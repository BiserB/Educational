
using System;

public class Tiger: Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed)
    {
        Name = name;
        Weight = weight;
        LivingRegion = livingRegion;
        Breed = breed;
    }

    public override bool Eat(Food food)
    {
        if (food.Type != "Meat")
        {
            return false;
        }
        Weight += food.Quantity * 1.0;
        FoodEaten += food.Quantity;
        return true;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("ROAR!!!");
    }
}
