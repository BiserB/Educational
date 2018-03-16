
using System.Collections.Generic;

public static class CarFactory
{
    public static Car Create(List<string> args, Tyre tyre)
    {       
        int hp = int.Parse(args[2]);
        double fuelAmount = double.Parse(args[3]);

        return new Car(hp, fuelAmount, tyre);
    }
}
