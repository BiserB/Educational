using System;
using System.Collections.Generic;
using System.Text;

namespace t01.Models
{
    class UltrasoftTyre : Tyre
    {
        private decimal grip;

        public UltrasoftTyre(string name, decimal hardness, decimal degradation, decimal grip) 
             : base(name, hardness, degradation)
        {
            this.Name = "Ultrasoft";
            this.Grip = grip;
        }

        public decimal Grip
        {
            get { return grip; }
            set { grip = value; }
        }
    }
}
