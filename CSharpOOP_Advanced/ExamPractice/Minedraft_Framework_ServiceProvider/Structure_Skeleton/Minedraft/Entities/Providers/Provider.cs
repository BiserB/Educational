using System;

public abstract class Provider : IProvider
{    
    private const int InitialDurability = 1000;
    
    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= 100;
        if (Durability <= 0)
        {
            throw new ArgumentException("Broken!");
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}