
public class WaterBender : Bender
{
    private readonly string TYPE = "Water Bender";
    private readonly string MODIFIER = "Water Clarity";
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity): base(name, power)
    {
        WaterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get { return waterClarity; }
        set { waterClarity = value; }
    }

    public override double GetPower()
    {
        return WaterClarity * Power;
    }

    public override string ToString()
    {
        return $"Water Bender: {Name}, Power: {Power}, Water Clarity: {WaterClarity:f2}";
    }
}
