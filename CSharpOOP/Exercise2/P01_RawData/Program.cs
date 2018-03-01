using System;
using System.Collections.Generic;
using System.Linq;


public class RawData
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            Tire[] tires = new Tire[] { new Tire(), new Tire(), new Tire(), new Tire() };
            tires[0].Pressure = double.Parse(parameters[5]);
            tires[0].Age = int.Parse(parameters[6]);
            tires[1].Pressure = double.Parse(parameters[7]);
            tires[1].Age = int.Parse(parameters[8]);
            tires[2].Pressure = double.Parse(parameters[9]);
            tires[2].Age = int.Parse(parameters[10]);
            tires[3].Pressure = double.Parse(parameters[11]);
            tires[3].Age = int.Parse(parameters[12]);
            
            cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tires));
        }

        string command = Console.ReadLine();
        if (command == "fragile")
        {
            var selection = cars
                .Where(c => c.CargoType == "fragile" && c.Tires.Any(t => t.Pressure < 1)).ToList();

            selection.ForEach(c => Console.WriteLine(c.Model));            
        }
        else
        {
            var selection = cars
                .Where(c => c.CargoType == "flamable" && c.EnginePower > 250).ToList();

            selection.ForEach(c => Console.WriteLine(c.Model));
        }
    }
}
