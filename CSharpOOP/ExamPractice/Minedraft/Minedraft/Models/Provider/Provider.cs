
using System;

public abstract class Provider : Miner
{
    private readonly string ERROR_MESSAGE = "Provider is not registered, because of it's {0}";
    
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
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException(string.Format(ERROR_MESSAGE, nameof(EnergyOutput)));
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        string result = $" Provider - {Id}" + Environment.NewLine;
        result += $"Energy Output: {energyOutput}";
        return result;
    }
}
