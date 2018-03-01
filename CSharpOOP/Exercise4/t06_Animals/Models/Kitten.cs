using System;
using System.Collections.Generic;
using System.Text;

namespace t06_Animals.Models
{
    class Kitten : Cat
    {
        public Kitten(string name, int age, Gender gender): base(name, age, gender)
        {
        }
        
        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }        
    }
}
