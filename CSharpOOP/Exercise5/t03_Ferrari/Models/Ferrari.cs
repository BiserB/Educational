using System;

public class Ferrari : ICar
{
    private string make;
    private string model;
    private Driver driver;

    public Ferrari(Driver driver)
    {
        Make = "Ferrari";
        Model = "488-Spider";
        Driver = driver;
    }
    
    public string Make
    {
        get { return make; }
        set { make = value; }
    }
    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public Driver Driver
    {
        get { return driver; }
        set { driver = value; }
    }

    public string PushTheGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public string UseBreaks()
    {
        return "Brakes!";
    }

    public override string ToString()
    {
        string result = $"{Model}/{UseBreaks()}/{PushTheGasPedal()}/{Driver.Name}";
        return result;
    }
}
