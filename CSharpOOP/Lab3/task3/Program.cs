using System;
using System.Collections.Generic;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                string firstName = cmdArgs[0];
                string lastName = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                decimal salary = decimal.Parse(cmdArgs[3]);
                try
                {
                    var person = new Person(firstName,
                                        lastName,
                                        age,
                                        salary);
                    persons.Add(person);
                }
                catch (ArgumentException exc)
                {
                    Console.WriteLine(exc.Message);
                }             
                               
            }
            var bonus = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(bonus));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
