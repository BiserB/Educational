
using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion)
    {
        Name = name;
        Weight = weight;
        LivingRegion = livingRegion;
    }

    public override bool Eat(Food food)
    {
        if (food.Type != "Meat")
        {
            return false;
        }
        Weight += food.Quantity * 0.40;
        FoodEaten += food.Quantity;
        return true;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }

    public override string ToString()
    {
        return $"{Name}, {Weight}, {LivingRegion}, {FoodEaten}";
    }
}
