using System;

public class Provider: Machine
{
    private static readonly int MAX_ENERGY_OUTPUT = 10000;
    private static readonly string ERR_MSG = "Provider is not registered, because of it's EnergyOutput";
        
    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {        
        EnergyOutput = energyOutput;
    }
    
    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            CheckValue(value);
            energyOutput = value;
        }
    }

    private void CheckValue(double value)
    {
        if (value < 0 || value > MAX_ENERGY_OUTPUT)
        {
            throw new ArgumentException(ERR_MSG);
        }
    }

    public override string ToString()
    {
        string result = $" Provider - {Id}" + Environment.NewLine;
        result += $"Energy Output: {energyOutput}";
        return result;
    }
}
