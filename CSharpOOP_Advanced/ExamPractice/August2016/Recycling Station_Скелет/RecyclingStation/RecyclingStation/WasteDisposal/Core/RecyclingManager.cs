
using System;

public class RecyclingManager : IRecyclingManager
{
    private IGarbageProcessor garbageProcessor;
    private IWasteFactory wasteFactory;

    private double energyBalance;
    private double capitalBalance;

    private double energyRequired;
    private double capitalRequired;
    private string restrictedType; 

    public RecyclingManager(IGarbageProcessor garbageProcessor, IWasteFactory wasteFactory)
    {
        this.garbageProcessor = garbageProcessor;
        this.wasteFactory = wasteFactory;
        this.energyBalance = 0;
        this.capitalBalance = 0;

        this.energyRequired = 0;
        this.capitalRequired = 0;
        this.restrictedType = null;
    }

    public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
    {
        if (type == restrictedType)
        {
            if (energyBalance < energyRequired || capitalBalance < capitalRequired)
            {
                return "Processing Denied!";
            }
        }

        IWaste waste = this.wasteFactory.CreateWaste(name, weight, volumePerKg, type);

        IProcessingData result =  this.garbageProcessor.ProcessWaste(waste);

       this.energyBalance += result.EnergyBalance;
        this.capitalBalance += result.CapitalBalance;

        return $"{weight:f2} kg of {name} successfully processed!";
    }

    public string ChangeManagementRequirement(double energyRequired, double capitalRequired, string garbageType)
    {
        this.energyRequired = energyRequired;
        this.capitalRequired = capitalRequired;
        this.restrictedType = garbageType;

        return "Management requirement changed!";
    }

    public string Status()
    {
        return $"Energy: {this.energyBalance:f2} Capital: {this.capitalBalance:f2}";
    }
}
