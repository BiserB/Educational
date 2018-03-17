
using System;
using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester Create(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyReq = double.Parse(args[3]);

        switch (type)
        {
            case "Hammer":                
                return new HammerHarvester(id, oreOutput, energyReq);
            case "Sonic":
                int sonicFactor = int.Parse(args[4]);
                return new SonicHarvester(id, oreOutput, energyReq, sonicFactor);
            default:
                throw new ArgumentException("Invalid type");
        }
    }
}
