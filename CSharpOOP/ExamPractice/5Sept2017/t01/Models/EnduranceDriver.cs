using System;
using System.Collections.Generic;
using System.Text;

namespace t01.Models
{
    class EnduranceDriver : Driver
    {
        public EnduranceDriver(string name, decimal totalTime, Car car, decimal fuelConsumptionPerKm)
                        : base ( name,  totalTime,  car, fuelConsumptionPerKm)
        {
            FuelConsumptionPerKm = 1.5m;            
        }
    }
}
