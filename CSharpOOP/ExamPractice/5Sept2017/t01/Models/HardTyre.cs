using System;
using System.Collections.Generic;
using System.Text;

namespace t01.Models
{
    class HardTyre : Tyre
    {
        private decimal grip;

        public HardTyre(string name, decimal hardness, decimal degradation, decimal grip) 
             : base(name, hardness, degradation)
        {
            this.Name = "Hard";
            this.Grip = grip;
        }

        public decimal Grip
        {
            get { return grip; }
            set { grip = value; }
        }
    }
}
