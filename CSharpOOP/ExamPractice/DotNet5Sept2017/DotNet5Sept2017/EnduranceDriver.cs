using System;
using System.Collections.Generic;
using System.Text;


public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, decimal totalTime, Car car, decimal fuelConsumptionPerKm)
                    : base(name, totalTime, car, fuelConsumptionPerKm)
    {
        FuelConsumptionPerKm = 1.5m;
    }
}
