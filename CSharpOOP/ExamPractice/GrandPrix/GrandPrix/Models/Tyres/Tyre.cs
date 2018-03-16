
using System;

public abstract class Tyre
{    
    private double degradation;

    public Tyre(string name, double hardness)
    {
        Name = name;
        Hardness = hardness;
        Degradation = 100;
    }

    public string Name { get; }

    public double Hardness { get; }

    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            degradation = value;
        }
    }

    public virtual void Wear()
    {
        Degradation -= Hardness;
    }

}