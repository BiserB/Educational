
public class Truck : Vehicle
{
    private static readonly double ADDITIONAL_CONSUMPTION = 1.60;
    private static readonly double QTY_MODIFIER = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption + ADDITIONAL_CONSUMPTION)
    { }

    public override void Refuel(double quantity)
    {
        FuelQuantity += (quantity * QTY_MODIFIER);
    }
}
