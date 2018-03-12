using System;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    public Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Brand = brand;
        Model = model;
        YearOfProduction = yearOfProduction;
        Horsepower = horsepower;
        Acceleration = acceleration;
        Suspension = suspension;
        Durability = durability;
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int Horsepower
    {
        get { return horsepower; }
        set { horsepower = value; }
    }

    public int YearOfProduction
    {
        get { return yearOfProduction; }
        set { yearOfProduction = value; }
    }

    public int Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    public int Suspension
    {
        get { return suspension; }
        set { suspension = value; }
    }

    public int Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public int EnginePerformance()
    {
        return Horsepower / Acceleration;
    }

    public int SuspensionPerformance()
    {
        return Suspension + Durability;
    }

    public int OverallPerformance()
    {
        return EnginePerformance() + SuspensionPerformance();
    }

    public abstract void Upgrade(string extras);

    public override string ToString()
    {
        string result = $"{Brand} {Model} {YearOfProduction}" + Environment.NewLine;
        result += $"{Horsepower} HP, 100 m/h in {Acceleration} s" + Environment.NewLine;
        result += $"{Suspension} Suspension force, {Durability} Durability" + Environment.NewLine;
        return result;
    }
}