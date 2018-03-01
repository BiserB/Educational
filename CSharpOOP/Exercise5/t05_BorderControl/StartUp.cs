// Problem 5. Border Control
// On each line there will be a piece of information for either a citizen or a robot.
// All citizens or robots whose Id ends with the specified digits(fake) must be detained.

using System;
using System.Collections.Generic;

public class StartUp
{
    private static List<IPopulation> population = new List<IPopulation>();    

    static void Main()
    {        
        string input = "";
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split();            
            if (data.Length == 3)
            {
                NewCitizen(data);
            }
            else
            {
                NewRobot(data);
            }  
        }
        CheckPopulation();        
    }    

    private static void NewCitizen(string[] data)
    {        
        string name = data[0];
        int age = int.Parse(data[1]);
        string id = data[2];
        population.Add(new Citizen(id, name, age));
    }

    private static void NewRobot(string[] data)
    {
        string model = data[0];        
        string id = data[1];
        population.Add(new Robot(id, model));
    }

    private static void CheckPopulation()
    {
        string fake = Console.ReadLine();
        foreach (var item in population)
        {
            if (item.Id.EndsWith(fake))
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
