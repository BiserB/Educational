
[RecyclableStrategy(typeof(RecyclableStrategy))]
public class Recyclable : Waste
{
    public Recyclable(string name, double weight, double volumePerKg) 
               : base(name, weight, volumePerKg)
    {
    }
}