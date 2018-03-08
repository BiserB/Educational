
public class WaterMonument : Monument
{
    private readonly string TYPE = "Water";
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity): base(name)
    {
        WaterAffinity = waterAffinity;
    }

    public int WaterAffinity
    {
        get { return waterAffinity; }
        set { waterAffinity = value; }
    }

    public override int GetAffinity()
    {
        return WaterAffinity;
    }

    public override string ToString()
    {
        return $"{TYPE} Monument: {Name}, {TYPE} Affinity: {WaterAffinity}";
    }
}
