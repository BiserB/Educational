
public class AirMonument : Monument
{
    private readonly string TYPE = "Air";
    private int airAffinity;

    public AirMonument(string name, int airAffinity) : base(name)
    {
        AirAffinity = airAffinity;
    }

    public int AirAffinity
    {
        get { return airAffinity; }
        set { airAffinity = value; }
    }

    public override int GetAffinity()
    {
        return AirAffinity;
    }

    public override string ToString()
    {
        return $"{TYPE} Monument: {Name}, {TYPE} Affinity: {AirAffinity}";
    }
}
