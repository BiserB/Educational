
public class EarthBender : Bender
{
    private readonly string TYPE = "Earth Bender";
    private readonly string MODIFIER = "Ground Saturation";
    private double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        GroundSaturation = groundSaturation;
    }

    public double GroundSaturation
    {
        get { return groundSaturation; }
        set { groundSaturation = value; }
    }

    public override double GetPower()
    {
        return GroundSaturation * Power;
    }

    public override string ToString()
    {
        return $"Earth Bender: {Name}, Power: {Power}, Ground Saturation: {GroundSaturation:f2}";
    }
}
