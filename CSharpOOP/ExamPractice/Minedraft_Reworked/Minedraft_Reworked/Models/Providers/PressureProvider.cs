
public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        EnergyOutput = EnergyOutput * 1.5;
    }

    public override string ToString()
    {
        return "Pressure" + base.ToString();
    }
}