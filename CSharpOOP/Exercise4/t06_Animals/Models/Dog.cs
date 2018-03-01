using System;


namespace t06_Animals.Models
{
    class Dog : Animal
    {
        public Dog(string name, int age, Gender gender) : base(name, age, gender)
        { }
        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
