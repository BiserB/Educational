using System;

public class Car
{
    private readonly int MAX_TANK_CAPACITY = 160;

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

    public Tyre Tyre
    {
        get { return tyre; }
        private set { tyre = value; }
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
            if (value <= MAX_TANK_CAPACITY)
            {
                fuelAmount = value;
            }
            else
            {
                fuelAmount = MAX_TANK_CAPACITY;
            };
        }
    }

    public void Refuel(double fuel)
    {
        FuelAmount += fuel;
    }

    public void ReduceFuel(int lapLength, double fuelConsumption)
    {
        FuelAmount -= (lapLength * fuelConsumption);
    }

    public void ChangeTyre(Tyre newTyre)
    {
        Tyre = newTyre;
    }
}