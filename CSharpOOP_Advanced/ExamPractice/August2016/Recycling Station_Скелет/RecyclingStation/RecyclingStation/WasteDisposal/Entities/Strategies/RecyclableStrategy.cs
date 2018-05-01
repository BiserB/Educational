
public class RecyclableStrategy : GarbageDisposalStrategy
{
    protected override double CalculateCapitalBalance(IWaste garbage)
    {
        double capitalEarned = 400 * garbage.Weight;
        
        return capitalEarned ;
    }

    protected override double CalculateEnergyBalance(IWaste garbage)
    {
        double energyProduced = 0;
        double energyUsed = 0.5 * garbage.CalcVolume();

        return energyProduced - energyUsed;
    }
}
