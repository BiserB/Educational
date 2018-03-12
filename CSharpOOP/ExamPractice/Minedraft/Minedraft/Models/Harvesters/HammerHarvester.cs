
public class HammerHarvester: Harvester
{    
    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
                    : base(id, oreOutput , energyRequirement)
    {
        OreOutput = oreOutput * 3.0;
        EnergyRequirement = energyRequirement * 2.0;
    }

    public override string ToString()
    {
        return "Hammer" + base.ToString();
    }
}
