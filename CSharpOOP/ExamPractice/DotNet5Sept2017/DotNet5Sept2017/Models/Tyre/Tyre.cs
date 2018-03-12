
using System;

public abstract class Tyre
{
    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        Name = name;
        Hardness = hardness;
        Degradation = 100;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public double Hardness
    {
        get { return hardness; }
        private set { hardness = value; }
    }

    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
        }

    }

    public virtual void TyreWear()
    {
        Degradation -= Hardness ;
    }
}