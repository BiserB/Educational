using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Car> cars = new List<Car>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] carTokens = Console.ReadLine().Split();
            string carModel = carTokens[0];
            decimal fuelQuantity = decimal.Parse(carTokens[1]);
            decimal consumptionPerKm = decimal.Parse(carTokens[2]);

            Car car = new Car(carModel, fuelQuantity, consumptionPerKm );            
            cars.Add(car);
        }
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] inputTokens = input.Split();
            string carModel = inputTokens[1];
            decimal desiredDistance = decimal.Parse(inputTokens[2]);
            Car currentCar = cars.Find(c => c.Model == carModel);

            currentCar.Travel(desiredDistance);

            input = Console.ReadLine();
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }
}

public class Car
{   
    public Car(string carModel, decimal fuelQuantity, decimal consumptionPerKm)
    {
        this.Model = carModel;
        this.FuelAmount = fuelQuantity;
        this.FuelConsumptionPerKm = consumptionPerKm;
    }

    public string Model { get; set; }
    public decimal FuelAmount { get; set; }
    public decimal FuelConsumptionPerKm { get; set; }
    public decimal DistanceTraveled { get; set; }

    public void Travel(decimal distance)
    {
        if (this.FuelConsumptionPerKm * distance <= this.FuelAmount)
        {
            this.FuelAmount -= FuelConsumptionPerKm * distance;
            this.DistanceTraveled += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:f2} {this.DistanceTraveled}";
    }

}