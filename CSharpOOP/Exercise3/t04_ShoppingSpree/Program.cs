using System;
using System.Collections.Generic;
using System.Linq;

namespace t04_ShoppingSpree
{
    public class Program
    {
        private static List<Person> persons = new List<Person>();
        private static List<Product> products = new List<Product>();

        static void Main()
        {
            PeopleDataInput();

            ProductsDataInput();

            Shoping();

            PrintResult();
        }       

        private static void ProductsDataInput()
        {
            string[] line = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string data in line)
            {
                string[] nameMoney = data.Split('=',StringSplitOptions.RemoveEmptyEntries);
                string name = nameMoney[0];
                decimal money = decimal.Parse(nameMoney[1]);                
                try
                {
                    products.Add(new Product(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }

        private static void PeopleDataInput()
        {            
            string[] line = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string data in line)
            {
                string[] nameMoney = data.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = nameMoney[0];
                decimal money = decimal.Parse(nameMoney[1]);
                try
                {
                    persons.Add(new Person(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }                
            }            
        }

        private static void Shoping()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] personProduct = input.Split();
                var person = persons.FirstOrDefault(p => p.Name == personProduct[0]);
                var product = products.FirstOrDefault(p => p.Name == personProduct[1]);                
                person.BuyProduct(product);
            }
        }

        private static void PrintResult()
        {
            foreach (var person in persons)
            {
                string purchased = "Nothing bought";
                if (person.Bag.Count > 0)
                {
                    purchased = String.Join(", ", person.Bag.Select(p => p.Name));
                }
                Console.WriteLine($"{person.Name} - {purchased}");                
            }
        }
    }
}
