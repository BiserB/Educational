using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private PersonFactory factory ;
    private SortedSet<Person> personsSorted;
    private HashSet<Person> personsHashed;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        factory = new PersonFactory();
        personsSorted = new SortedSet<Person>();
        personsHashed = new HashSet<Person>();
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
        

        writer.WriteLine(personsSorted.Count.ToString());

        writer.WriteLine(personsHashed.Count.ToString());
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

            personsSorted.Add(newPerson);
            personsHashed.Add(newPerson);

            count--;
        }        
    }
}