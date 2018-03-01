using System;
using System.Collections.Generic;

public class Program
{
    private static List<Person> persons = new List<Person>();
    private static Team newTeam = new Team("test");

    static void Main(string[] args)
    {
        DataInput();

        MakeATeam();

        PlayersCount();
    }

    private static void PlayersCount()
    {
        Console.WriteLine($"First team has {newTeam.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {newTeam.ReserveTeam.Count} players.");
    }

    private static void MakeATeam()
    {
        
        persons.ForEach(p => newTeam.AddPlayer(p));
    }

    private static void DataInput()
    {
        var lines = int.Parse(Console.ReadLine());
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
    }
}
