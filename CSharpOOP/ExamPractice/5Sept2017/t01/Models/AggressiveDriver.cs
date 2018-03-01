using System;
using System.Collections.Generic;
using System.Text;

namespace t01.Models
{
    class AggressiveDriver : Driver
    {
        public AggressiveDriver(string name, decimal totalTime, Car car, decimal fuelConsumptionPerKm)
                        : base ( name,  totalTime,  car, fuelConsumptionPerKm)
        {
            FuelConsumptionPerKm = 2.7m;
            Speed *= 1.3m;
        }
    }
}
