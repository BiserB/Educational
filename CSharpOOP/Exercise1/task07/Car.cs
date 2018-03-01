using System;

public class Car
{    
    public string Model { get; set; }
    public decimal FuelAmount { get; set; }
    public decimal FuelConsumption { get; set; }
    public int Distance { get; set; }

    public Car(string model, decimal fuelAmount, decimal fuelConsumption)
    {
        this.Model = model;
        this.FuelConsumption = fuelConsumption;
        this.FuelAmount = fuelAmount;        
    }

    // model, fuel amount, fuel consumption for 1 kilometer and distance traveled.    

    public void Travel(int distance)
    {
        if (this.FuelConsumption * distance <= this.FuelAmount)
        {
            this.FuelAmount -= FuelConsumption * distance;
            this.Distance += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:f2} {this.Distance}";        
    }
}

