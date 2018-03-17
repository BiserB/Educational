
using System;

public abstract class Harvester : Machine
{
    private static readonly string ERR_MSG_ENERGY = "Harvester is not registered, because of it's EnergyRequirement";
    private static readonly string ERR_MSG_ORE = "Harvester is not registered, because of it's OreOutput";
    private static readonly int MAX_ENERGY_REQ = 20000;
        
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
                    : base(id)
    {        
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }
    
    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            CheckOre(value);
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            CheckEnergy(value);
            energyRequirement = value;
        }
    }

    private static void CheckOre(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException(ERR_MSG_ORE);
        }
    }

    private static void CheckEnergy(double value)
    {
        if (value < 0 || value > MAX_ENERGY_REQ)
        {
            throw new ArgumentException(ERR_MSG_ENERGY);
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
