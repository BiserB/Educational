// Problem 7. Food Shortage
// Extend the code from your previous task

using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{    
    private static List<IBuyer> buyers = new List<IBuyer>();

    static void Main()
    {
        int num = int.Parse(Console.ReadLine());

        for (int i = 0; i < num; i++)
        {
            string[] data = Console.ReadLine().Split();
            if (data.Length == 4)
            {
                EnterCitizen(data);
            }
            else if (data.Length == 3)
            {
                EnterRebel(data);
            }

        }

        BuyFood();

        CalculateFood();

    }   
    
    private static void EnterRebel(string[] data)
    {
        string name = data[0];
        int age = int.Parse(data[1]);
        string group = data[2];
        Rebel rebel = new Rebel(name, age, group);
        IBuyer buyer = buyers.FirstOrDefault(r => r.Name == name);
        if (buyer == null)
        {
            buyers.Add(rebel);
        }
    }

    private static void EnterCitizen(string[] data)
    {
        string name = data[0];
        int age = int.Parse(data[1]);
        string id = data[2];
        string birthdate = data[3];
        Citizen citizen = new Citizen(id, name, age, birthdate);
        IBuyer buyer = buyers.FirstOrDefault(r => r.Name == name);
        if (buyer == null)
        {
            buyers.Add(citizen);
        }
    }

    private static void BuyFood()
    {
        string name = "";
        while ((name = Console.ReadLine()) != "End")
        {
            IBuyer buyer = buyers.FirstOrDefault(r => r.Name == name);
            if (buyer != null)
            {
                buyer.BuyFood();
                continue;
            }
        }        
    }

    private static void CalculateFood()
    {
        int totalFood = 0;
        foreach (var buyer in buyers)
        {            
            totalFood += buyer.Food;
        }
        Console.WriteLine(totalFood);
    }

}

