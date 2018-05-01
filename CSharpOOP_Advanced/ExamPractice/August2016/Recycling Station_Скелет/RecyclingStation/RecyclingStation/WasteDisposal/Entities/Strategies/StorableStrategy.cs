
public class StorableStrategy : GarbageDisposalStrategy
{
    protected override double CalculateCapitalBalance(IWaste garbage)
    {        
        return -0.65 * garbage.CalcVolume();
    }

    protected override double CalculateEnergyBalance(IWaste garbage)
    {        
        return -0.13 * garbage.CalcVolume();
    }
}
