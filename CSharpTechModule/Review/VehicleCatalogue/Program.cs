using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            var register = new List<Vehicle>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                register.Add(AddVehicle(input));
                input = Console.ReadLine();
            }
            string model = Console.ReadLine();
            double carsPower = 0.0d;
            double carsCount = 0.0d;
            double trucksPower = 0.0d;
            double trucksCount = 0.0d;
            while (model != "Close the Catalogue")
            {
                foreach (var item in register.Where(pr => pr.Model == model))
                {
                    Console.WriteLine("Type: {0}", item.Type);
                    Console.WriteLine("Model: {0}", item.Model);
                    Console.WriteLine("Color: {0}", item.Color);
                    Console.WriteLine("Horsepower: {0}", item.Horsepower);
                    if (item.Type == "car")
                    {
                        carsPower += item.Horsepower;
                        carsCount++;
                    }
                    else
                    {
                        trucksPower += item.Horsepower;
                        trucksCount++;
                    }
                }                
                model = Console.ReadLine();
            }
            Console.WriteLine("Cars have average horsepower of: {0:0.00}.", carsPower/carsCount);
            Console.WriteLine("Trucks have average horsepower of: {0:0.00}.", trucksPower/trucksCount);
        }
        public static Vehicle AddVehicle(string input)
        {
            string[] data = input.Split(' ');
            string type = data[0];
            string model = data[1];
            string color = data[2];
            int horsepower = int.Parse(data[3]);
            return new Vehicle
            {
                Type = type,
                Model = model,
                Color = color,
                Horsepower = horsepower
            };
        }
    }
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }
}
