// Define a class Car that holds information about model, engine, cargo 
// and a collection of exactly 4 tires. 

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Car> garage = new List<Car>();
        
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            string model = data[0];
            int engineSpeed = int.Parse(data[1]);
            int enginePower = int.Parse(data[2]);
            int cargoWeight = int.Parse(data[3]);
            string cargoType = data[4];
            double tire1Pressure = double.Parse(data[5]);
            int tire1Age = int.Parse(data[6]);
            double tire2Pressure = double.Parse(data[7]);
            int tire2Age = int.Parse(data[8]);
            double tire3Pressure = double.Parse(data[9]);
            int tire3Age = int.Parse(data[10]);
            double tire4Pressure = double.Parse(data[11]);
            int tire4Age = int.Parse(data[12]);

            Car newCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, 
                tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
            garage.Add(newCar);
        }
        string request = Console.ReadLine();
        if (request == "fragile")
        {
            var tireProblems = garage.Where(c => c.Tire1Pressure < 1 || c.Tire2Pressure < 1 || c.Tire3Pressure < 1 || c.Tire4Pressure < 1).ToList();
            foreach (Car c in tireProblems.Where(c => c.CargoType == "fragile" ))
            {
                Console.WriteLine(c.Model);
            }
        }
        else if (request == "flamable")
        {
            var powerEngines = garage.Where(c => c.EnginePower > 250).ToList();
            foreach (Car c in powerEngines.Where(c => c.CargoType == "flamable"))
            {
                Console.WriteLine(c.Model);
            }
        }
        
    }
}
