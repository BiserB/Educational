using System;
using System.Collections.Generic;
using System.Linq;
using t06_Animals.Models;

namespace t06_Animals
{
    public class Program
    {
        private static List<Animal> animals = new List<Animal>();
        static void Main()
        {
            string command = Console.ReadLine();
            while (command != "Beast!")
            {              
                CreateAnimal(command);

                command = Console.ReadLine();
            }

            PrintAnimals();
        }

        
        private static void CreateAnimal(string command)
        {
            string[] data = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string name = data[0];
                int age = 0;
                Gender gender;
                bool ageOK = int.TryParse(data[1], out age);
                bool genderOK = Gender.TryParse(data[2], out gender);
                if (!ageOK || !genderOK)
                {
                    throw new ArgumentException("Invalid input!");
                }
                Animal newAnimal = null;
                switch (command)
                {
                    case "Dog":
                        newAnimal = new Dog(name, age, gender);                        
                        break;
                    case "Cat":
                        newAnimal = new Cat(name, age, gender);                        
                        break;
                    case "Frog":
                        newAnimal = new Frog(name, age, gender);                        
                        break;
                    case "Tomcat":
                        gender = Gender.Male;
                        newAnimal = new Tomcat(name, age, gender);                        
                        break;
                    case "Kitten":
                        gender = Gender.Female;
                        newAnimal = new Kitten(name, age, gender);                        
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");                        
                }
                animals.Add(newAnimal);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }           
        }

        private static void PrintAnimals()
        {
            foreach (Animal a in animals)
            {
                Console.WriteLine(a);
                a.ProduceSound();
            }
        }

    }
}
