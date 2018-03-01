using System;
using System.Collections.Generic;
using System.Text;

namespace t06_Animals.Models
{
    abstract class Animal
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return name; }            
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }
        public Gender Gender
        {
            get { return gender; }
            private set { gender = value; }
        }

        public abstract void ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name}{Environment.NewLine}{Name} {Age} {Gender}";
        }
    }
}
