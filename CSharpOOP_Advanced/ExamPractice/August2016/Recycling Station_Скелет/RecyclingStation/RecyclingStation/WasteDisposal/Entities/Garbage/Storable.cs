
[StorableStrategy(typeof(StorableStrategy))]
public class Storable : Waste
{
    public Storable(string name, double weight, double volumePerKg) 
        : base(name, weight, volumePerKg)
    {
    }
}
