// 1. Define a class Person with private fields for name and age and public properties Name and Age.
// 2. Add 3 constructors to the Person class from the last task, use constructor chaining to reuse code:
// 3. Create a class Family. The class should have list of people, a method for adding members 
//    and a method returning the oldest family member
// 4. Program that reads from the console N lines of personal information 
//    and then prints all people whose age is more than 30 years, sorted in alphabetical order.


using System;
using System.Collections.Generic;
using System.Linq;



public class Program
{
    static void Main()
    {
        List<Person> register = new List<Person>();
        int n = int.Parse(Console.ReadLine());
        while (n > 0)
        {
            string[] data = Console.ReadLine().Split();
            string name = data[0];
            int age = int.Parse(data[1]);
            register.Add(new Person(age, name));
            n--;
        }

        foreach (var person in register.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList())
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }

        //Family newFamily = new Family();
        //int n = int.Parse(Console.ReadLine());
        //while (n > 0)
        //{
        //    string[] data = Console.ReadLine().Split();
        //    string name = data[0];
        //    int age = int.Parse(data[1]);
        //    newFamily.AddMember(new Person(age, name));
        //    n--;
        //}
        //var oldest = newFamily.GetOldestMember();
        //Console.WriteLine(oldest.Name + " " + oldest.Age);

    }
}

