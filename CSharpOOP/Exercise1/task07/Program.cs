// Implement a program that keeps track of cars and their fuel and supports methods for moving the cars.

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<Car> garage = new List<Car>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            string model = data[0];
            decimal fuelAmount = decimal.Parse(data[1]);
            decimal fuelConsumption = decimal.Parse(data[2]);
            var newCar = new Car(model, fuelAmount, fuelConsumption );
            garage.Add(newCar);
        }
        string command = "";
        while ((command = Console.ReadLine()) != "End")
        {
            string[] data = command.Split();
            string model = data[1];
            int distance = int.Parse(data[2]);
            Car selected = garage.FirstOrDefault(c => c.Model == model);
            selected.Travel(distance);
        }
        foreach (var car in garage)
        {
            Console.WriteLine(car);
        }
    }
}

