using System;


public class Program
{
    static void Main()
    {
        Car car = (Car)Factory();
        Truck truck = (Truck)Factory();
        Bus bus = (Bus)Factory();

        int cnt = int.Parse(Console.ReadLine());

        while (cnt > 0)
        {
            string command = Console.ReadLine();
            string[] data = command.Split();
            string action = data[0] + data[1];
            double argument = double.Parse(data[2]);

            try
            {
                switch (action)
                {
                    case "DriveCar":
                        Console.WriteLine(car.Drive(argument));
                        break;
                    case "DriveTruck":
                        Console.WriteLine(truck.Drive(argument));
                        break;
                    case "DriveBus":
                        Console.WriteLine(bus.Drive(argument));
                        break;
                    case "DriveEmptyBus":
                        Console.WriteLine(bus.DriveEmpty(argument));
                        break;
                    case "RefuelCar":
                        car.Refuel(argument);
                        break;
                    case "RefuelTruck":
                        truck.Refuel(argument);
                        break;
                    case "RefuelBus":
                        bus.Refuel(argument);
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }            
            cnt--;
        }
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static Vehicle Factory()
    {
        string[] part = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double fuelQty = double.Parse(part[1]);
        double fuelConsumption = double.Parse(part[2]);
        double capacity = double.Parse(part[3]);
        switch (part[0])
        {
            case "Car":
                return new Car(fuelQty, fuelConsumption, capacity);
            case "Truck":
                return new Truck(fuelQty, fuelConsumption, capacity);
            case "Bus":
                return new Bus(fuelQty, fuelConsumption, capacity);
            default:
                return null;
        }
    }


}
