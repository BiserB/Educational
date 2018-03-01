// Name – a string
// TotalTime – a floating-point number
// Car - parameter of type Car
// FuelConsumptionPerKm – a floating-point number
// Speed – a floating-point number


public class Car
{
    // private readonly decimal MAX_CAPACITY = 160m;

    private int hp;
    private decimal fuelAmount;
    private Tyre tyre;

    public Car(int hp, decimal fuelAmount, Tyre tyre)
    {
        Hp = hp;
        FuelAmount = fuelAmount;
        Tyre = tyre;
    }

    public Tyre Tyre
    {
        get { return tyre; }
        set { tyre = value; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public decimal FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public void ConsumeFuel()
    {

    }

}