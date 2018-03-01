using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            string firstName = cmdArgs[0];
            string lastName = cmdArgs[1];
            int age = int.Parse(cmdArgs[2]);
            var person = new Person(firstName, lastName, age);
            persons.Add(person);
        }

        persons.OrderBy(p => p.FirstName)
               .ThenBy(p => p.Age)
               .ToList()
               .ForEach(p => Console.WriteLine(p.ToString()));
    }
}
