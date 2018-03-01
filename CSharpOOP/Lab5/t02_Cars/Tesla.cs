using System;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        Model = model;
        Color = color;
        Battery = battery;
    }

    public string Model { get; set; }
    public string Color { get; set; }
    public int Battery { get; set; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        string result = $"{Color} Tesla {Model} with {Battery} Batteries" + Environment.NewLine;
        result += Start() + Environment.NewLine + Stop();
        return result;
    }
}