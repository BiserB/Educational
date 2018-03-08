
public abstract class Bender
{
    
    private readonly string MODIFIER = "";
    private string name;
    private int power;

    public Bender(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public abstract double GetPower();
}

