using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DraftManager
{
    private List<Harvester> harvesters = new List<Harvester>();
    private List<Provider> providers = new List<Provider>();
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;

    public DraftManager()
    {
        harvesters = new List<Harvester>();
        providers = new List<Provider>();
        mode = "Full";
        totalStoredEnergy = 0;
        totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = Factory.CreateHarvester(arguments);
            harvesters.Add(harvester);
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = Factory.CreateProvider(arguments);
            providers.Add(provider);
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }

    public string Day()
    {
        string result = "A day has passed." + Environment.NewLine;
        double energyProvided = 0;
        if (providers.Count > 0)
        {
            energyProvided = providers.Sum(p => p.EnergyOutput);
        }        
        result += $"Energy Provided: {energyProvided}" + Environment.NewLine;
        totalStoredEnergy += energyProvided;
        double requiredEnergy = 0;
        double summedOreOutput = 0;
        if (harvesters.Count > 0)
        {
            requiredEnergy = harvesters.Sum(h => h.EnergyRequirement);
            summedOreOutput = harvesters.Sum(h => h.OreOutput);
        }
        
        if (mode == "Energy" || totalStoredEnergy < requiredEnergy)
        {
            result += "Plumbus Ore Mined: 0";
            return result;
        }
        if (mode == "Half")
        {
            requiredEnergy = requiredEnergy * 0.6;
            summedOreOutput *= 0.50;
        }

        totalStoredEnergy -= requiredEnergy; 
        totalMinedOre += summedOreOutput;
        result += $"Plumbus Ore Mined: {summedOreOutput}";
        mode = "Full";
        return result;
    }

    public string Mode(List<string> arguments)
    {
        mode = arguments[0];
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        string result = $"No element found with id - {id}";
        var findedHarvester = harvesters.FirstOrDefault(h => h.Id == id);
        var findedProvider = providers.FirstOrDefault(h => h.Id == id);
        if (findedHarvester != null)
        {
            result = findedHarvester.ToString();
        }
        else if (findedProvider != null)
        {
            result = findedProvider.ToString();
        }
        return result;            
    }

    public string ShutDown()
    {
        string result = "System Shutdown" + Environment.NewLine;
        result += $"Total Energy Stored: {totalStoredEnergy}" + Environment.NewLine;
        result += $"Total Mined Plumbus Ore: {totalMinedOre}";
        return result;
    }
    
    
}
