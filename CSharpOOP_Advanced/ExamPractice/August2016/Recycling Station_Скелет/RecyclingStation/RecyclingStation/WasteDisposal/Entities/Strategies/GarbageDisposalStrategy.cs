
public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
{
    
    public GarbageDisposalStrategy()
    {        
    }

    protected abstract double CalculateEnergyBalance(IWaste garbage);

    protected abstract double CalculateCapitalBalance(IWaste garbage);

    public IProcessingData ProcessGarbage(IWaste garbage)
    {
        double energyBalance = CalculateEnergyBalance(garbage);
        double capitalBalance = CalculateCapitalBalance(garbage);

        return new ProcessingData(energyBalance, capitalBalance);
    }
}
