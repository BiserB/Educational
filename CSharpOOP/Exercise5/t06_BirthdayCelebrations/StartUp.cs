// Extend the program from your last task to add birthdates to citizens
// and include a class Pet, pets have a name and a birthdate.
// You will receive a specific year. Print all birthdates (of both citizens and pets) in that year.


using System;
using System.Collections.Generic;

public class StartUp
{
    private static List<ICreature> creatures = new List<ICreature>();
    static void Main()
    {
        string input = "";
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split();
            if (data[0] == "Citizen")
            {
                NewCitizen(data);
            }
            else if (data[0] == "Pet")
            {
                NewPet(data);
            }
        }
        string year = Console.ReadLine();
        FindBirthdates(year);
    }    

    private static void NewCitizen(string[] data)
    {
        string name = data[1];
        int age = int.Parse(data[2]);
        string id = data[3];
        string birthdate = data[4];
        creatures.Add(new Citizen(id, name, age, birthdate));
    }

    private static void NewPet(string[] data)
    {
        string name = data[1];
        string birthdate = data[2];
        creatures.Add(new Pet(name, birthdate));
    }

    private static void FindBirthdates(string year)
    {
        foreach (var creature in creatures)
        {
            if (creature.Birthdate.EndsWith(year))
            {
                Console.WriteLine(creature.Birthdate);
            }
        }
    }
}