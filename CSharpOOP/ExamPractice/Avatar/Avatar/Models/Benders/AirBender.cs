
using System;

public class AirBender : Bender
{    
    private double aerialIntegrity;    

    public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
    {
        AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity
    {
        get { return aerialIntegrity; }
        set { aerialIntegrity = value; }
    }

    public override double GetPower()
    {
        return AerialIntegrity * Power;
    }

    public override string ToString()
    {
        return $"Air Bender: {Name}, Power: {Power}, Aerial Integrity: {AerialIntegrity:f2}";
    }
}
