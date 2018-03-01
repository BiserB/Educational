using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<Engine> engines = new List<Engine>();
        List<Car> cars = new List<Car>();

        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
           
            string model = input[0];
            int power = int.Parse(input[1]);            
            int displacement = 0;
            string efficiency = "n/a";
            if (input.Length == 3)
            {                               
                bool isDigit = int.TryParse(input[2], out displacement);
                if (!isDigit)
                {
                    efficiency = input[2];
                }               

            }
            else if(input.Length == 4)
            {
                displacement = int.Parse(input[2]);
                efficiency = input[3];
            }
            Engine newEngine = new Engine(model, power, displacement, efficiency);
            engines.Add(newEngine);
        }
        //-----------------------------------------------------------------------------
        num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string model = input[0];
            string engineModel = input[1];
            int weight = 0;
            string color = "n/a";
            if (input.Length == 3)
            {
                bool isDigit = int.TryParse(input[2], out weight);
                if (!isDigit)
                {
                    color = input[2];
                }
            }
            else if (input.Length == 4)
            {
                weight = int.Parse(input[2]);
                color = input[3];
            }
            Engine selectedEngine = engines.FirstOrDefault(e => e.Model == engineModel);
            Car newCar = new Car(model, selectedEngine, weight, color);
            cars.Add(newCar);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine("  {0}:", car.Engine.Model);
            Console.WriteLine("    Power: {0}", car.Engine.Power);
            if (car.Engine.Displacement == 0)
            {
                Console.WriteLine("    Displacement: n/a");
            }
            else
            {
                Console.WriteLine("    Displacement: {0}", car.Engine.Displacement);
            }            
            Console.WriteLine("    Efficiency: {0}", car.Engine.Efficiency);
            if (car.Weight == 0)
            {
                Console.WriteLine("  Weight: n/a");
            }
            else
            {
                Console.WriteLine("  Weight: {0}", car.Weight);
            }            
            Console.WriteLine("  Color: {0}", car.Color);

        }

    }
}
