public class Car
{
    private string model;
    private int engineSpeed;
    private int enginePower;
    private int cargoWeight;
    private string cargoType;
    private double tire1Pressure;
    private int tire1Age;
    private double tire2Pressure;
    private int tire2Age;
    private double tire3Pressure;
    private int tire3Age;
    private double tire4Pressure;
    private int tire4Age;

    public string Model { get; private set; }
    public int EngineSpeed { get; private set; }
    public int EnginePower { get; private set; }
    public int CargoWeight { get; private set; }
    public string CargoType { get; private set; }

    public double Tire1Pressure { get; private set; }
    public int Tire1Age { get; private set; }
    public double Tire2Pressure { get; private set; }
    public int Tire2Age { get; private set; }
    public double Tire3Pressure { get; private set; }
    public int Tire3Age { get; private set; }
    public double Tire4Pressure { get; private set; }
    public int Tire4Age { get; private set; }

    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
    {
        this.Model = model;
        this.EngineSpeed = engineSpeed;
        this.EnginePower = enginePower;
        this.CargoWeight = cargoWeight;
        this.CargoType = cargoType;
        this.Tire1Pressure = tire1Pressure;
        this.Tire1Age = tire1Age;
        this.Tire2Pressure = tire2Pressure;
        this.Tire2Age = tire2Age;
        this.Tire3Pressure = tire3Pressure;
        this.Tire3Age = tire3Age;
        this.Tire4Pressure = tire4Pressure;
        this.Tire4Age = tire4Age;
    }


}