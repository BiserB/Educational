
using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string line = "";

        while ((line = Console.ReadLine()) != "End")
        {
            Animal animal = Factory(line);
            animal.ProduceSound();

            string[] foodLine = Console.ReadLine().Split();
            string type = foodLine[0];
            int quantity = int.Parse(foodLine[1]);
            Food food = new Food(type, quantity);
            if (!animal.Eat(food))
            {
                Console.WriteLine($"{animal.GetType().Name} does not eat {food.Type}!");
            }            
            
            animals.Add(animal);
        }

        foreach (var a in animals)
        {
            Console.WriteLine($"{a.GetType().Name} [{a}]");
        }
    }

    private static Animal Factory(string line)
    {
        string[] s = line.Split();
        string type = s[0];
        string name = s[1];
        double weight = double.Parse(s[2]);

        switch (type)
        {
            case "Owl":
                double wingSize = double.Parse( s[3]);                
                return new Owl(name, weight, wingSize);
            case "Hen":
                double wing = double.Parse(s[3]);
                return new Hen(name, weight, wing);
            case "Dog":                
                return new Dog(name, weight, s[3]);
            case "Mouse":
                return new Mouse(name, weight, s[3]);
            case "Cat":
                return new Cat(name, weight, s[3], s[4]);
            case "Tiger":
                return new Tiger(name, weight, s[3], s[4]);
            default:
                return null;
        }
    }
}
