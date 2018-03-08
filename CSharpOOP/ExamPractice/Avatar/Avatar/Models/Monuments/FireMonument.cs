
public class FireMonument: Monument
{
    private readonly string TYPE = "Fire";
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity): base(name)
    {
        FireAffinity = fireAffinity;
    }

    public int FireAffinity
    {
        get { return fireAffinity; }
        set { fireAffinity = value; }
    }

    public override int GetAffinity()
    {
        return FireAffinity;
    }

    public override string ToString()
    {
        return $"{TYPE} Monument: {Name}, {TYPE} Affinity: {FireAffinity}";
    }
}
