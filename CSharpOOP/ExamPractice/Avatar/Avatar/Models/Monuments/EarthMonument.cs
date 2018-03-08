
public class EarthMonument: Monument
{
    private readonly string TYPE = "Earth";
    private int earthAffinity;

    public EarthMonument(string name, int earthAffinity): base(name)
    {
        EarthAffinity = earthAffinity;
    }

    public int EarthAffinity
    {
        get { return earthAffinity; }
        set { earthAffinity = value; }
    }

    public override int GetAffinity()
    {
        return EarthAffinity;
    }

    public override string ToString()
    {
        return $"{TYPE} Monument: {Name}, {TYPE} Affinity: {EarthAffinity}";
    }
}
