// A Pizza is made of dough and different toppings. 
// You should model a class Pizza, which should have a name, dough and toppings as fields.
// Every type of ingredient should have its own class.

using System;
using t05_PizzaCalories.Models;
using t05_PizzaCalories.Models.Enums;

namespace t05_PizzaCalories
{
    public class Program
    {
        private static Pizza pizza = new Pizza();
        static void Main()
        {
            try
            {
                string input = Console.ReadLine();
                string[] data = input.Split();
                if (data[0] == "Pizza")
                {
                    pizza = new Pizza(data[1]);
                }
                data = Console.ReadLine().Split();
                if (data[0] == "Dough")
                {
                    MakeDough(data);
                }

                while ((input = Console.ReadLine()) != "END")
                {
                    data = input.Split(); 
                    if (data[0] == "Topping")
                    {
                        MakeTopping(data);
                    }
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

       
        private static void MakeTopping(string[] data)
        {
            ToppingType type = ToppingType.Meat;
            decimal weight = decimal.Parse(data[2]);
            switch (data[1].ToLower())
            {
                case "cheese":
                    type = ToppingType.Cheese;
                    break;
                case "sauce":
                    type = ToppingType.Sauce;
                    break;
                case "veggies":
                    type = ToppingType.Veggies;
                    break;
                case "meat":                    
                    break;
                default:
                    throw new ArgumentException($"Cannot place {data[1]} on top of your pizza.");
                  
            }
            Topping topping = new Topping(type, weight);
            pizza.AddTopping(topping);
            //Console.WriteLine("{0:f2}", topping.Calories);
        }

        private static void MakeDough(string[] data)
        {
            FlourType flour = FlourType.white;
            BakingTechnique tech = BakingTechnique.homemade;
            decimal weight = decimal.Parse(data[3]);
            switch (data[1].ToLower())
            {
                case "white":
                    break;
                case "wholegrain":
                    flour = FlourType.wholegrain;
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough.");                    
            }
            switch (data[2].ToLower())
            {
                case "crispy":
                    tech = BakingTechnique.crispy;
                    break;
                case "chewy":
                    tech = BakingTechnique.chewy;
                    break;
                case "homemade":                    
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough.");                    
            }
            Dough dough = new Dough(flour, tech, weight);
            pizza.AddDough(dough);
            //Console.WriteLine("{0:f2}", dough.Calories);
        }
    }
}
