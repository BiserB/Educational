﻿
public class SonicHarvester: Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
                   : base(id, oreOutput, energyRequirement )
    {
        SonicFactor = sonicFactor;
        EnergyRequirement = energyRequirement / sonicFactor;
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        protected set { sonicFactor = value; }
    }

    public override string ToString()
    {
        return "Sonic" + base.ToString();
    }
}
