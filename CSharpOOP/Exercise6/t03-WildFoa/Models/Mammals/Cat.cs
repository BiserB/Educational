
using System;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed)
    {
        Name = name;
        Weight = weight;
        LivingRegion = livingRegion;
        Breed = breed;
    }

    public override bool Eat(Food food)
    {
        if (food.Type != "Vegetable" && food.Type != "Meat")
        {
            return false;
        }
        Weight += food.Quantity * 0.30;
        FoodEaten += food.Quantity;
        return true;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}
