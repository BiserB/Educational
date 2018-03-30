
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static List<Task> tasks = new List<Task>();
    static List<Task> schedule = new List<Task>();

    static int totalSteps = 0;

    static int totalValue = 0;

    static void Main()
    {
        ReadTasks();

        OrderTasks();

        string scheduleTasks = string.Join(" -> ", schedule.Select(s => s.Id));

        Console.WriteLine("Optimal schedule: {0}", scheduleTasks);
        Console.WriteLine("Total value: {0}", totalValue);
    }

    private static void OrderTasks()
    {
        int step = 0;

        while (tasks.Count > 0 && step < totalSteps)
        {     
            foreach (var task in tasks)
            {
                task.CalcRating(step);
            }

            Task selected = tasks.OrderByDescending(t => t.Rating).First();

            totalValue += selected.Value;

            schedule.Add(selected);

            tasks.Remove(selected);

            step++;

            tasks.RemoveAll(t => t.Deadline == step);            
        }
        
    }

    private static void ReadTasks()
    {
        string[] input = Console.ReadLine().Split();

        int count = int.Parse(input[1]);

        for (int i = 1; i <= count; i++)
        {
            input = Console.ReadLine().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            int value = int.Parse(input[0]);
            int deadline = int.Parse(input[1]);

            Task task = new Task(i, value, deadline);
            tasks.Add(task);

            if (totalSteps < deadline)
            {
                totalSteps = deadline;
            }
        }
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
    public int Deadline { get; }

    public double Rating { get; private set; }

    public void CalcRating(int step)
    {       
        Rating = (double)Value / (Deadline - step);
    }
}