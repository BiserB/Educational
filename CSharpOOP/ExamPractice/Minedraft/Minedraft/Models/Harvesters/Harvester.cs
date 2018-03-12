
using System;

public abstract class Harvester : Miner
{
    private readonly string ERROR_MESSAGE = "Harvester is not registered, because of it's {0}";    
    private double oreOutput;
    private double energyRequirement;    

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {        
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }    
    
    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(ERROR_MESSAGE, nameof(OreOutput)));
            }
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException(string.Format(ERROR_MESSAGE, nameof(EnergyRequirement)));
            }
            energyRequirement = value;
        }
    }

    public override string ToString()
    {
        string result = $" Harvester - {Id}" + Environment.NewLine;
        result += $"Ore Output: {OreOutput}" + Environment.NewLine;
        result += $"Energy Requirement: {EnergyRequirement}";
        return result;
    }
}
