using System;
using System.Text;

public class Program
{
    static void Main()
    {
        Car car = (Car)Factory();
        Truck truck = (Truck)Factory();
        int cnt = int.Parse(Console.ReadLine());
        
        while (cnt > 0)
        {
            string command = Console.ReadLine();
            string[] data = command.Split();
            string action = data[0] + data[1];
            double argument = double.Parse(data[2]);            

            switch (action)
            {
                case "DriveCar":
                    Console.WriteLine(car.Drive(argument));                  
                    break;
                case "DriveTruck":
                    Console.WriteLine(truck.Drive(argument));
                    break;
                case "RefuelCar":
                    car.Refuel(argument);
                    break;
                case "RefuelTruck":
                    truck.Refuel(argument);
                    break;                
            } 
            cnt--;
        }        
        Console.WriteLine(car);
        Console.WriteLine(truck);

        
    }  

    private static Vehicle Factory()
    {
        string[] part = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double fuelQty = double.Parse(part[1]);
        double fuelConsumption = double.Parse(part[2]);
        switch (part[0])
        {
            case "Car":
                return new Car(fuelQty, fuelConsumption);
            case "Truck":
                return new Truck(fuelQty, fuelConsumption);
            default:
                return null;
        }
    }
}
