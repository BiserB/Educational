
public class BurnableStrategy : GarbageDisposalStrategy
{
    protected override double CalculateCapitalBalance(IWaste garbage)
    {       
        return 0;
    }

    protected override double CalculateEnergyBalance(IWaste garbage)
    {        
        return 0.8 * garbage.CalcVolume();
    }
}
