using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                string firstName = data[0];
                string secondName = data[1];
                int age = int.Parse(data[2]);
                double salary = double.Parse(data[3]);
                var newPerson = new Person(firstName, secondName, age, salary);
                persons.Add(newPerson);
            }
            foreach (var item in persons)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
