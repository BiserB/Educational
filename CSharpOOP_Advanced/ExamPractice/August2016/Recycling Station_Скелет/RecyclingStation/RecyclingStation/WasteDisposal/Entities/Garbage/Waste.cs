
public abstract class Waste : IWaste
{
    public Waste(string name, double weight, double volumePerKg)
    {
        this.Name = name;
        this.Weight = weight;
        this.VolumePerKg = volumePerKg;
        
    }
    public string Name { get; }

    public double Weight { get; }

    public double VolumePerKg { get; }    
}
