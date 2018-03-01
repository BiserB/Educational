// Name – a string
// TotalTime – a floating-point number
// Car - parameter of type Car
// FuelConsumptionPerKm – a floating-point number
// Speed – a floating-point number




public class Tyre
{
    private string name;
    private decimal hardness;
    private decimal degradation;

    public Tyre(string name, decimal hardness)
    {
        Name = name;
        Hardness = hardness;
        Degradation = 100m;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public decimal Hardness
    {
        get { return hardness; }
        set { hardness = value; }
    }
    public decimal Degradation
    {
        get { return degradation; }
        set { degradation = value; }
    }

    public void TyreWear()
    {
        this.Degradation -= this.Hardness;
    }

}