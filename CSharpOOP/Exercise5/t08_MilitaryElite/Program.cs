using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<ISoldier> soldiers = new List<ISoldier>();

    static void Main()
    {
        string input = "";
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split();
            SoldierCreator(data);
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }

    private static void SoldierCreator(string[] data)
    {
        int id = int.Parse(data[1]);
        string firstName = data[2];
        string lastName = data[3];
        decimal salary = decimal.Parse(data[4]);
        switch (data[0])
        {
            case "Private":
                soldiers.Add(new Private(id, firstName, lastName, salary));
                break;
            case "LeutenantGeneral":
                var general = new LeutenantGeneral(id, firstName, lastName, salary);
                for (int i = 5; i < data.Length ; i++)
                {
                    int privateId = int.Parse(data[i]);
                    Private p = (Private)soldiers.FirstOrDefault(s => s.Id == privateId);
                    general.AddPrivate(p);
                }
                soldiers.Add(general);
                break;
            case "Engineer":
                if (Corps.TryParse(data[5], out Corps corps))
                {
                    var engineer = new Engineer(id, firstName, lastName, salary, corps);
                    for (int i = 6; i < data.Length - 1; i += 2)
                    {
                        string partName = data[i];
                        int hours = int.Parse(data[i + 1]);
                        Repair r = new Repair(partName, hours);
                        engineer.AddRepair(r);
                    }
                    soldiers.Add(engineer);
                } 
                break;
            case "Commando":
                if (Corps.TryParse(data[5], out Corps c))
                {
                    var commando = new Commando(id, firstName, lastName, salary, c);
                    for (int i = 6; i < data.Length - 1; i += 2)
                    {
                        string codeName = data[i];
                        if (State.TryParse(data[i + 1], out State state))
                        {
                            Mission m = new Mission(codeName, state);
                            commando.AddMission(m);
                        }                        
                    }
                    soldiers.Add(commando);
                }
                break;
            case "Spy":
                int codeNumber = int.Parse(data[4]);
                soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                break;
            default:
                break;
        }
    }
}
