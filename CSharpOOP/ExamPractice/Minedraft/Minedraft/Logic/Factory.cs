using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Factory
{
    public static Harvester CreateHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);
        Harvester harvester = null;
        if (type == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);            
        }
        else if (type == "Hammer")
        {
            harvester = new HammerHarvester(id, oreOutput, energyRequirement);            
        }
        return harvester;
    }

    public static Provider CreateProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);
        Provider provider = null;

        if (type == "Solar")
        {
            provider = new SolarProvider(id, energyOutput);            
        }
        else if (type == "Pressure")
        {
            provider = new PressureProvider(id, energyOutput);            
        }
        return provider;
    }
}
