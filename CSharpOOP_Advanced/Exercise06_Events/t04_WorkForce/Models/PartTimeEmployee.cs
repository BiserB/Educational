using System;
using System.Collections.Generic;
using System.Text;

namespace t04_WorkForce.Models
{
    public class PartTimeEmployee : Employee
    {
        private static readonly double HOURS_PER_WEEK = 20;

        public PartTimeEmployee(string name) 
                            : base(name, HOURS_PER_WEEK)
        {
        }
    }
}
