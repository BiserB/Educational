using System;
using System.Collections.Generic;
using System.Text;


public class UltrasoftTyre : Tyre
{
    private double grip;
    private double degradation;

    public UltrasoftTyre(double hardness,  double grip)
         : base("Ultrasoft", hardness)
    {        
        Grip = grip;
    }

    public double Grip
    {
        get { return grip; }
        private set { grip = value; }
    }

    public override double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
        }
    }

    public override void TyreWear()
    {
        Degradation -= (Hardness + Grip);
    }    
}
