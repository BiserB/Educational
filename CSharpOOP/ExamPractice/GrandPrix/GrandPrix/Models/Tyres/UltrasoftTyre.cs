using System;


public class UltrasoftTyre : Tyre
{
    private double grip;
    private double degradation;

    public UltrasoftTyre(double hardness, double grip)
        : base("Ultrasoft", hardness)
    {
        Grip = grip;
    }

    public double Grip { get; }

    public override double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            degradation = value;
        }
    }

    public override void Wear()
    {
        Degradation -= (Hardness + Grip);
    }

}
