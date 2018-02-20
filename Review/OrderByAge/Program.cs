using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> register = new List<Person>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                
                register.Add(Person.AddPerson(input));
                
                input = Console.ReadLine();
            }
            foreach (var item in register.OrderBy(pr => pr.Age))
            {
                Console.WriteLine("{0} with ID: {1} is {2} years old.", item.Name, item.ID, item.Age);
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }

        public static Person AddPerson(string input)
        {
            string[] data = input.Split(' ');
            string name = data[0];
            int id = int.Parse(data[1]);
            int age = int.Parse(data[2]);
            return new Person
            {
                Name = name,
                ID = id,
                Age = age
            };
        }
    }

}
