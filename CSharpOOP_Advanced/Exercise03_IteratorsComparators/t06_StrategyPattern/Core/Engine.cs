using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private PersonFactory factory ;
    private SortedSet<Person> personsByName;
    private SortedSet<Person> personsByAge;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        factory = new PersonFactory();
        personsByName = new SortedSet<Person>(new PersonNameComparer());
        personsByAge = new SortedSet<Person>(new PersonAgeComparer());
    }

    public void Run()
    {
        try
        {
            EnterPersons();            

            PrintStatistics();
        }
        catch (ArgumentException ae)
        {
            writer.WriteLine(ae.Message);
        }
        
    }

    private void PrintStatistics()
    {
        foreach (var person in personsByName)
        {
            writer.WriteLine(person.ToString());
        }

        foreach (var person in personsByAge)
        {
            writer.WriteLine(person.ToString());
        }
    }

    private void EnterPersons()
    {
        int count = int.Parse(Console.ReadLine());
        
        while (count > 0)
        {
            string input = Console.ReadLine();

            string[] data = input.Split();

            string name = data[0];
            int age = int.Parse(data[1]);

            Person newPerson = factory.Create(name, age);

            personsByName.Add(newPerson);
            personsByAge.Add(newPerson);

            count--;
        }        
    }
}