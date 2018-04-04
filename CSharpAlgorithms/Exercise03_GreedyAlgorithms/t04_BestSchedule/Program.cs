using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine()
                .Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
        int count = int.Parse(input[1]);
        List<Lecture> lectures = new List<Lecture>(count);
        List<Lecture> schedule = new List<Lecture>();

        for (int i = 0; i < count; i++)
        {
            string[] args = Console.ReadLine()
                .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
            string name = args[0];
            int start = int.Parse(args[1]);
            int end = int.Parse(args[2]);

            Lecture lecture = new Lecture(name, start, end);

            lectures.Add(lecture);
        }

        while (lectures.Count > 0)
        {
            int earliest = lectures.Min(l => l.EndHour);

            Lecture chosenLecture = lectures.First(l => l.EndHour == earliest);

            lectures.Remove(chosenLecture);

            schedule.Add(chosenLecture);

            for (int i = 0; i < lectures.Count; i++)
            {
                if (lectures[i].StartHour < chosenLecture.EndHour)
                {
                    lectures.Remove(lectures[i]);
                    i--;
                }
            }
        }

        Console.WriteLine($"Lectures ({schedule.Count}):");

        foreach (var l in schedule)
        {
            Console.WriteLine($"{l.StartHour}-{l.EndHour} -> {l.Name}");
        }

    }
}

public class Lecture
{
    public Lecture(string name, int start, int end)
    {
        Name = name;
        StartHour = start;
        EndHour = end;
    }
    public string Name { get; }
    public int StartHour { get; }
    public int EndHour { get; }
}