using System;
using System.Collections.Generic;
using System.Text;
using t04_WorkForce.Contracts;

namespace t04_WorkForce.Models
{
    public abstract class Employee : IEmployee
    {
        public Employee(string name, double hours)
        {
            this.Name = name;
            this.Hours = hours;
        }

        public string Name { get; }

        public double Hours { get; }
    }
}
