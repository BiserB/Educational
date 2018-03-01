// Name – a string
// TotalTime – a floating-point number
// Car - parameter of type Car
// FuelConsumptionPerKm – a floating-point number
// Speed – a floating-point number

using System;
using System.Collections.Generic;
using System.Text;

namespace t01.Models
{
    internal class Driver
    {        
        private string name;        
        private decimal totalTime;
        private Car car;
        private decimal fuelConsumptionPerKm;
        private decimal speed;

        public Driver(string name, decimal totalTime, Car car, decimal fuelConsumptionPerKm)
        {
            Name = name;
            TotalTime = totalTime;
            Car = car;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            Speed = speed;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public decimal TotalTime
        {
            get { return totalTime; }
            set { totalTime = value; }
        }
        public Car Car
        {
            get { return car; }
            set { car = value; }
        }
        public decimal FuelConsumptionPerKm
        {
            get { return fuelConsumptionPerKm; }
            set { fuelConsumptionPerKm = value; }
        }
        public decimal Speed
        {
            get { return CalcSpeed(); }
            set { speed = CalcSpeed(); }
        }       

        private decimal CalcSpeed()
        {
            return (car.Hp + car.TyreType.Degradation) / car.FuelAmount;
        }
    }
}
