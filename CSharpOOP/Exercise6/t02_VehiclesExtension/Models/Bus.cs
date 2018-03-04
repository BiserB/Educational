public class Bus: Vehicle
{
    private static readonly double ADDITIONAL_CONSUMPTION = 1.4;    

    public Bus(double fuelQuantity, double fuelConsumption, double capacity)
        : base(fuelQuantity, fuelConsumption + ADDITIONAL_CONSUMPTION, capacity)
    { }

    public string DriveEmpty(double distance)
    {
        base.FuelConsumption -= ADDITIONAL_CONSUMPTION;
        string result = Drive(distance);
        return result;
    }

}