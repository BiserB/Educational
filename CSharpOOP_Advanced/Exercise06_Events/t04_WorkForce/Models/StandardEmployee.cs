using System;
using System.Collections.Generic;
using System.Text;

namespace t04_WorkForce.Models
{
    public class StandardEmployee : Employee
    {
        private static readonly double HOURS_PER_WEEK = 40;

        public StandardEmployee(string name) 
                         : base(name, HOURS_PER_WEEK)
        {
        }
    }
}
