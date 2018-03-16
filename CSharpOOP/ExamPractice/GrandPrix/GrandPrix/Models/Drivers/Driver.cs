
using System;

public abstract class Driver
{    
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;    

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        Name = name;
        TotalTime = 0;
        Car = car;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
        IsRacing = true;
    }
       
    public string Name { get; }

    public Car Car
    {
        get { return car; }
        private set { car = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        private set { totalTime = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        private set { fuelConsumptionPerKm = value; }
    }   

    public virtual double Speed
    {
        get
        {
            return (Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;
        }
    }

    public bool IsRacing { get; private set; }

    public string FailureReason { get; private set; }

    private string Status
    {
        get
        {
            if (IsRacing)
            {
                return $"{TotalTime:f3}";
            }
            return FailureReason;
        }
    }

    public void CompleteLap(int lapLength)
    {        
        TotalTime += 60 / (lapLength / Speed);

        Car.ReduceFuel(lapLength, FuelConsumptionPerKm);

        Car.Tyre.Wear();
    }

    public void AddTime(int time)
    {
        TotalTime += time;
    }

    public void ReduceTime(int time)
    {
        TotalTime -= time;
    }

    internal void Fail(string message)
    {
        IsRacing = false;
        FailureReason = message;
    }

    public override string ToString()
    {
        return $"{Name} {Status}";
    }
    
}
