
public class FireBender : Bender
{
    private readonly string TYPE = "Fire Bender";
    private readonly string MODIFIER = "Heat Aggression";
    private double heatAggression;

    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        HeatAggression = heatAggression;
    }

    public double HeatAggression
    {
        get { return heatAggression; }
        set { heatAggression = value; }
    }

    public override double GetPower()
    {
        return HeatAggression * Power; 
    }

    public override string ToString()
    {
        return $"Fire Bender: {Name}, Power: {Power}, Heat Aggression: {HeatAggression:f2}";
    }
}
