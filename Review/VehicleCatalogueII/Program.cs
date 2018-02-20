using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogueII
{
    class Program
    {
        static void Main(string[] args)
        {
            var register = new List<Vehicle>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                register.Add(NewVehicle(input));
                input = Console.ReadLine();
            }
            string model = Console.ReadLine();
            while (model != "Close the Catalogue")
            {
                foreach (var item in register.Where(pr => pr.Model == model))
                {
                    Console.WriteLine("Type: {0}", item.Type);
                    Console.WriteLine("Model: {0}", item.Model);
                    Console.WriteLine("Color: {0}", item.Color);
                    Console.WriteLine("Horsepower: {0}", item.Horsepower);                    
                }
                model = Console.ReadLine();
            }
            double carsPower = 0.0d;
            double trucksPower = 0.0d;
            if (register.Where(pr => pr.Type == "Car").Count() != 0)
            {
                carsPower = register.Where(pr => pr.Type == "Car").Select(pr => pr.Horsepower).Average();
            }
            if ((register.Where(pr => pr.Type == "Truck").Count() != 0))
            {
                trucksPower = register.Where(pr => pr.Type == "Truck").Select(pr => pr.Horsepower).Average();
            }            
            Console.WriteLine("Cars have average horsepower of: {0:0.00}.", carsPower);
            Console.WriteLine("Trucks have average horsepower of: {0:0.00}.", trucksPower);
        }
        public static Vehicle NewVehicle(string input)
        {
            string[] data = input.Split(' ');
            string type = data[0].ToLower();
            string model = data[1];
            string color = data[2];
            int horsepower = int.Parse(data[3]);
            if (type == "car")
            {
                type = "Car";
            }
            else
            {
                type = "Truck";
            }
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
