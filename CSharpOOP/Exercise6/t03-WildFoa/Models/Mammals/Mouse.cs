
using System;

public class Mouse: Mammal
{
    public Mouse(string name, double weight, string livingRegion)
    {
        Name = name;
        Weight = weight;
        LivingRegion = livingRegion;
    }

    public override bool Eat(Food food)
    {
        if (food.Type != "Vegetable" && food.Type != "Fruit")
        {
            return false;
        }
        Weight += food.Quantity * 0.10;
        FoodEaten += food.Quantity;
        return true;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Squeak");
    }

    public override string ToString()
    {
        return $"{Name}, {Weight}, {LivingRegion}, {FoodEaten}";
    }
}
