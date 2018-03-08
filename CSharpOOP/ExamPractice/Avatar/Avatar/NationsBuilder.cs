using System;
using System.Collections.Generic;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warHistory = new List<string>();

    public NationsBuilder()
    {
        nations = new Dictionary<string, Nation>()
        {
            { "Air", new Nation() },
            { "Fire", new Nation() },
            { "Earth", new Nation() },
            { "Water", new Nation() }
        };
    }

    public void AssignBender(List<string> args)
    {
        Bender bender = CreateBender(args);
        string type = args[1];
        nations[type].AddBender(bender);
    }

    public void AssignMonument(List<string> args)
    {
        Monument monument = CreateMonument(args);
        string type = args[1];
        nations[type].AddMonument(monument);
    }

    public string GetStatus(string type)
    {
        string result = $"{type} Nation" + Environment.NewLine + nations[type];
        return result;
    }

    public void IssueWar(string type)
    {
        Nation winner = nations[type];
        foreach (var nation in nations.Values)
        {
            if (nation.TotalPower() > winner.TotalPower())
            {
                winner = nation;
            }
        }
        foreach (var nation in nations.Values)
        {
            if (nation != winner)
            {
                nation.DeclareDefeat();
            }
        }
        warHistory.Add($"War {warHistory.Count + 1} issued by {type}");
    }

    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, warHistory);
    }

    private Bender CreateBender(List<string> args)
    {
        string type = args[1];
        string name = args[2];
        int power = int.Parse(args[3]);
        double modifier = double.Parse(args[4]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, modifier);

            case "Fire":
                return new FireBender(name, power, modifier);

            case "Water":
                return new WaterBender(name, power, modifier);

            case "Earth":
                return new EarthBender(name, power, modifier);

            default:
                throw new ArgumentException();
        }
    }

    private Monument CreateMonument(List<string> args)
    {
        string type = args[1];
        string name = args[2];
        int affinity = int.Parse(args[3]);

        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);

            case "Fire":
                return new FireMonument(name, affinity);

            case "Water":
                return new WaterMonument(name, affinity);

            case "Earth":
                return new EarthMonument(name, affinity);

            default:
                throw new ArgumentException();
        }
    }
}