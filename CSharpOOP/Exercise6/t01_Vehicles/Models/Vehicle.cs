public abstract class Vehicle
{   
    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; set; }
    public double FuelConsumption { get; set; }

    public string Drive(double distance)
    {
        if (distance * FuelConsumption > FuelQuantity)
        {
            return $"{this.GetType().Name} needs refueling";
        }
        this.FuelQuantity -= distance * this.FuelConsumption;
        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double quantity)
    {
        this.FuelQuantity += quantity;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}