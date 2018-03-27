using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private PersonFactory factory ;
    private List<Person> persons;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        factory = new PersonFactory();
        persons = new List<Person>();
    }

    public void Run()
    {
        try
        {
            EnterPersons();

            int personNumber = int.Parse(Console.ReadLine());

            PrintStatistics(personNumber);
        }
        catch (ArgumentException ae)
        {
            writer.WriteLine(ae.Message);
        }
        
    }

    private void PrintStatistics(int personNumber)
    {
        // { number of equal people} {number of not equal people} {total number of people}
                
        int total = persons.Count;

        if (personNumber >= total)
        {
            throw new ArgumentException("No matches");
        }
        Person wanted = persons[personNumber];

        int equal = 0;
        int notEqual = 0;        

        foreach (var person in persons)
        {
            if (person.CompareTo(wanted) == 0)
            {
                equal++;
            }
            else
            {
                notEqual++;
            }
        }

        writer.WriteLine($"{equal} {notEqual} {total}");
    }

    private void EnterPersons()
    {
        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] data = input.Split();

            string name = data[0];
            int age = int.Parse(data[1]);
            string town = data[2];

            Person newPerson = factory.Create(name, age, town);

            persons.Add(newPerson);

            input = Console.ReadLine();
        }        
    }
}