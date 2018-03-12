
using System;

public class Car
{
    private readonly double MAX_CAPACITY = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        Hp = hp;
        FuelAmount = fuelAmount;
        Tyre = tyre;
    }
    
    public int Hp
    {
        get { return hp; }
        private set { hp = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            if (value > MAX_CAPACITY)
            {
                fuelAmount = MAX_CAPACITY;
            }
            else
            {
                fuelAmount = value;
            }            
        }
    }

    public Tyre Tyre
    {
        get { return tyre; }
        private set { tyre = value; }
    }

    public void ConsumeFuel()
    {

    }

    public void Refuel(double fuel)
    {
        FuelAmount += fuel;
    }

}