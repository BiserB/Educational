using System;
using System.Linq;

public class Engine
{    
    private NationsBuilder builder;

    public Engine()
    {        
        builder = new NationsBuilder();
    }

    public void Run()
    {       
        string input = "";
        while ((input = Console.ReadLine()) != "Quit")
        {
            string[] data = input.Split();
            string type = data[0];
            switch (type)
            {
                case "Bender":
                    builder.AssignBender(data.ToList());
                    break;
                case "Monument":
                    builder.AssignMonument(data.ToList());
                    break;
                case "Status":
                    string status = builder.GetStatus(data[1]);
                    Console.WriteLine(status);
                    break;
                case "War":
                    builder.IssueWar(data[1]);
                    break;                              
            }
        }
        Console.WriteLine(builder.GetWarsRecord());
    }
}