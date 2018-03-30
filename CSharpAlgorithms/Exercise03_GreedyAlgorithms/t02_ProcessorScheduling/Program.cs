
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<Task> tasks = new List<Task>();
        List<Task> schedule = new List<Task>();
        int totalValue = 0;

        double maxDeadline = 0;

        string[] input = Console.ReadLine().Split();
        int count = int.Parse(input[1]);

        for (int i = 1; i <= count; i++)
        {
            input = Console.ReadLine().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            int value = int.Parse(input[0]);
            int deadline = int.Parse(input[1]);

            Task task = new Task(i, value, deadline);
            tasks.Add(task);

            if (maxDeadline < deadline)
            {
                maxDeadline = deadline;
            }
        }        

        for (int i = 1; i <= maxDeadline; i++)
        {
            Task selected = tasks.Where(t => t.Deadline <= i)
                                 .OrderByDescending(t => t.Value)
                                 .FirstOrDefault();

            if (selected == null)
            {
                selected = tasks.OrderByDescending(t => t.Value).First();
            }
            
            Console.WriteLine($"Selected = {selected.Value}");

            schedule.Add(selected);

            tasks.Remove(selected);
            tasks.RemoveAll(t => t.Deadline == i);
        }

        Console.WriteLine(string.Join(" -> ", schedule.Select(s => s.Id)));


    }
}

internal class Task
{
    public Task(int id, int value, int deadline)
    {
        Id = id;
        Value = value;
        Deadline = deadline;
    }

    public int Id { get; }
    public int Value { get; }
    public int Deadline { get; set; }
    
}