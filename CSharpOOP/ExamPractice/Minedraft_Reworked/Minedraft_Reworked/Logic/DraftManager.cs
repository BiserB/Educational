using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private readonly string RESULT = "A day has passed." + Environment.NewLine +
                                    "Energy Provided: {0}" + Environment.NewLine +
                                    "Plumbus Ore Mined: {1}";

    private List<Harvester> harvesters;
    private List<Provider> providers;

    private double energyStoredTotal;
    private double oreMinedTotal;

    private MineMode mode;

    public DraftManager()
    {
        harvesters = new List<Harvester>();
        providers = new List<Provider>();
        energyStoredTotal = 0;
        oreMinedTotal = 0;
        MineMode = MineMode.Full;
    }

    public MineMode MineMode
    {
        get { return mode; }
        private set { mode = value; }
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester h = HarvesterFactory.Create(arguments);
            harvesters.Add(h);
            return $"Successfully registered {arguments[0]} Harvester - {h.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider p = ProviderFactory.Create(arguments);
            providers.Add(p);
            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {
        double energyProvided = providers.Sum(p => p.EnergyOutput);
        energyStoredTotal += energyProvided;
        double energyNeeded = harvesters.Sum(h => h.EnergyRequirement);
        double oreMined = 0;

        if (MineMode == MineMode.Half)
        {
            energyNeeded *= 0.6;
        }
        else if (MineMode == MineMode.Energy)
        {
            return string.Format(RESULT, energyProvided, oreMined);
        }

        if (energyStoredTotal >= energyNeeded)
        {
            energyStoredTotal -= energyNeeded;
            oreMined = harvesters.Sum(h => h.OreOutput);
        }

        if (MineMode == MineMode.Half)
        {
            oreMined *= 0.5;
        }

        oreMinedTotal += oreMined;

        return string.Format(RESULT, energyProvided, oreMined );
    }

    public string Mode(List<string> arguments)
    {
        if (Enum.TryParse(arguments[0], out MineMode mode))
        {
            MineMode = mode;
        }
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        var harvester = harvesters.FirstOrDefault(h => h.Id == id);

        if (harvester != null)
        {
            return harvester.ToString();
        }

        var provider = providers.FirstOrDefault(p => p.Id == id);
        if (provider != null)
        {
            return provider.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {energyStoredTotal}");
        sb.AppendLine($"Total Mined Plumbus Ore: {oreMinedTotal}");

        return sb.ToString().TrimEnd(); 
    }
}
