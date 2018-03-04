using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double capacity; 

    public Vehicle(double fuelQuantity, double fuelConsumption, double capacity)
    {
        if (fuelQuantity <= capacity)
        {
            FuelQuantity = fuelQuantity;
        }                      
        FuelConsumption = fuelConsumption;
        Capacity = capacity;
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set
        {
            PositiveCheck(value);
            fuelQuantity = value;
        }
    }

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public double Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }

    public virtual string Drive(double distance)
    {
        if (distance * FuelConsumption > FuelQuantity)
        {
            return $"{GetType().Name} needs refueling";
        }
        FuelQuantity -= distance * FuelConsumption;
        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double quantity)
    {
        PositiveCheck(quantity);
        CapacityCheck(quantity);
        FuelQuantity += quantity;
    }

    protected void PositiveCheck(double quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
    }

    protected void CapacityCheck(double quantity)
    {
        if (quantity > Capacity - FuelQuantity)
        {
            throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
        }
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {FuelQuantity:f2}";
    }
}