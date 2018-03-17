
public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
                    : base(id, oreOutput, energyRequirement)
    {
        OreOutput = 3.0 * OreOutput;
        EnergyRequirement = 2.0 * EnergyRequirement;
    }

    public override string ToString()
    {
        return "Hammer" + base.ToString();
    }
}
