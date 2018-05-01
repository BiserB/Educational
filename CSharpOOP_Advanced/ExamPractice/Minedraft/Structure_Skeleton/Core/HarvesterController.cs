
using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory factory;
    private double modifier = 1;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.factory = new HarvesterFactory();
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);
        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }

    public string ChangeMode(string mode)
    {    
        switch (mode)
        {
            case "Energy":
                modifier = 0.2;
                break;

            case "Half":
                modifier = 0.5;
                break;

            case "Full":
                modifier = 1;
                break;            
        }

        List<IHarvester> brokenHarvesters = new List<IHarvester>();

        foreach (var harvester in harvesters)
        {            
            try
            {
                if (harvester.GetType() != typeof(InfinityHarvester))
                {
                    harvester.Broke();
                }               
            }
            catch (Exception)
            {
                brokenHarvesters.Add(harvester);
            }            
        }

        foreach (var harvester in brokenHarvesters)
        {
            harvesters.Remove(harvester);
        }

        return string.Format(Constants.ModeChanged, mode);
    }

    public string Produce()
    {
        double energyNeeded = harvesters.Sum(h => h.EnergyRequirement) * modifier;
        double oreProduced = 0;

        if (this.energyRepository.TakeEnergy(energyNeeded))
        {
            oreProduced = harvesters.Sum(h => h.Produce()) * modifier;
        }

        OreProduced += oreProduced;

        return string.Format(Constants.OreOutputToday, oreProduced);
    }

    
}
