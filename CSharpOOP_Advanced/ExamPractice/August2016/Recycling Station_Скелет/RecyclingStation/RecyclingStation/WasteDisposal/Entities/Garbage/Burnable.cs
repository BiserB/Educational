
[BurnableStrategy(typeof(BurnableStrategy))]
public class Burnable : Waste
{
    public Burnable(string name, double weight, double volumePerKg) 
             : base(name, weight, volumePerKg)
    {
    }
}
