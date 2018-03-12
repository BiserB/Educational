// Name – a string
// TotalTime – a floating-point number
// Car - parameter of type Car
// FuelConsumptionPerKm – a floating-point number
// Speed – a floating-point number

public class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    private double speed;

    public Driver(string name, double totalTime, Car car, double fuelConsumptionPerKm)
    {
        Name = name;
        TotalTime = totalTime;
        Car = car;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
        Speed = speed;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
    }

    public Car Car
    {
        get { return car; }
        set { car = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        set { fuelConsumptionPerKm = value; }
    }

    public double Speed
    {
        get { return CalcSpeed(); }
        set { speed = CalcSpeed(); }
    }

    private double CalcSpeed()
    {
        return (car.Hp + car.TyreType.Degradation) / car.FuelAmount;
    }
}