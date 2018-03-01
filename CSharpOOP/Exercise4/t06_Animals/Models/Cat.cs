using System;


namespace t06_Animals.Models
{
    class Cat : Animal
    {
        public Cat(string name, int age, Gender gender) : base(name, age, gender)
        { }
        public override void ProduceSound()
        {
            Console.WriteLine("Meow meow");
        }
    }
}
