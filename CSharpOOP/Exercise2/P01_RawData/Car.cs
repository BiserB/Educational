using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, Tire[] tires)
    {
        this.Model = model;
        this.EngineSpeed = engineSpeed;
        this.EnginePower = enginePower;
        this.CargoWeight = cargoWeight;
        this.CargoType = cargoType;
        this.Tires = tires;
    }
    public string Model { get; private set; }
    public int EngineSpeed { get; private set; }
    public int EnginePower { get; private set; }
    public int CargoWeight { get; private set; }
    public string CargoType { get; private set; }
    public Tire[] Tires { get; set; } = new Tire[4];
}
