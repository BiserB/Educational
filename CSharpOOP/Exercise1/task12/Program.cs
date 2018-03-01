using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    internal static List<Person> persons = new List<Person>();

    static void Main()
    {        
        string input = "";        
        while ((input = Console.ReadLine()) != "End")
        {            
            string[] data = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string name = data[0];
            string entry = data[1];
            Person person = persons.FirstOrDefault(p => p.Name == name);
            if (person == null)
            {
                person = new Person(name);
                persons.Add(person);
            }
            if (entry == "company")
            {
                string companyName = data[2];
                string department = data[3];
                decimal salary = decimal.Parse(data[4]);
                Company newCompany = new Company(companyName, department, salary);
                person.Company = newCompany;
            }
            else if (entry == "pokemon")
            {
                string pokemonName = data[2];
                string type = data[3];
                Pokemon newPokemon = new Pokemon(pokemonName, type);
                person.Pokemons.Add(newPokemon);
            }
            else if (entry == "parents")
            {
                string relativeName = data[2];
                string birthday = data[3];
                Relative newRelative = new Relative(relativeName, birthday);
                person.Parents.Add(newRelative);
            }
            else if (entry == "children")
            {
                string relativeName = data[2];
                string birthday = data[3];
                Relative newRelative = new Relative(relativeName, birthday);
                person.Children.Add(newRelative);
            }
            else if (entry == "car")
            {
                string model = data[2];
                int speed = int.Parse(data[3]);
                Car newCar = new Car(model, speed);
                person.Car = newCar;
            }
        }

        PrintResult();
        
    }
    public static void PrintResult()
    {
        string personName = Console.ReadLine();
        Person person = persons.FirstOrDefault(p => p.Name == personName);
        Console.WriteLine($"{person.Name}");

        Console.WriteLine("Company:");
        if (person.Company != null)
        {
            Console.WriteLine(person.Company);
        }

        Console.WriteLine($"Car:");
        if (person.Car != null)
        {
            Console.WriteLine(person.Car);
        }

        Console.WriteLine("Pokemon:");
        person.Pokemons.ForEach(p => Console.WriteLine(p));

        Console.WriteLine("Parents:");
        person.Parents.ForEach(p => Console.WriteLine(p));

        Console.WriteLine("Children:");
        person.Children.ForEach(c => Console.WriteLine(c));
    }
}
