using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        List<Car> garage = new List<Car>();
        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string[] data = Console.ReadLine().Split(' ');
            //string model,Engine engine, Tyre[] tyres, Cargo cargo
            string model = data[0];
            int speed = int.Parse(data[1]);
            int power = int.Parse(data[2]);
            Engine engine = new Engine(speed, power);
            int weight = int.Parse(data[3]);
            string type = data[4];
            Cargo cargo = new Cargo(weight, type);
            double tyre1pr = double.Parse(data[5]);
            int tyre1age = int.Parse(data[6]);
            Tyre tyre1 = new Tyre(tyre1pr, tyre1age);
            double tyre2pr = double.Parse(data[7]);
            int tyre2age = int.Parse(data[8]);
            Tyre tyre2 = new Tyre(tyre2pr, tyre2age);
            double tyre3pr = double.Parse(data[9]);
            int tyre3age = int.Parse(data[10]);
            Tyre tyre3 = new Tyre(tyre3pr, tyre3age);
            double tyre4pr = double.Parse(data[11]);
            int tyre4age = int.Parse(data[12]);
            Tyre tyre4 = new Tyre(tyre4pr, tyre4age);
            Tyre[] tyres = { tyre1, tyre2, tyre3, tyre4 };
            Car newCar = new Car(model, engine, tyres, cargo);
            garage.Add(newCar);
        }
        string cargoType = Console.ReadLine();
        if (cargoType == "fragile")
        {
            foreach (var car in garage.Where(c => c.CarCargo.Type == cargoType ))
            {
                bool lowPresure = false;
                foreach (var tyre in car.CarTyres)
                {
                    if (tyre.Presure < 1)
                    {
                        lowPresure = true;
                        break;
                    }
                }
                if (lowPresure)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
        else if (cargoType == "flammable")
        {            
            foreach (var car in garage.Where(c => c.CarCargo.Type == cargoType))
            {                
                if (car.CarEngine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
                
            }
        }

        
    }
}

