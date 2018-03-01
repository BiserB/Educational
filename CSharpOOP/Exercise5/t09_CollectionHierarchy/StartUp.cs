using System;
using System.Collections.Generic;
using System.Text;

public class StartUp
{
    static void Main(string[] args)
    {
        AddCollection ac = new AddCollection();
        AddRemoveCollection arc = new AddRemoveCollection();
        MyList myList = new MyList();

        string[] input = Console.ReadLine().Split();
        int counter = int.Parse(Console.ReadLine());

        List<int> result = new List<int>();
        foreach (var str in input)
        {
            result.Add(ac.Add(str));
        }
        Console.WriteLine(String.Join(" ", result));

        result.Clear();
        foreach (var str in input)
        {
            result.Add(arc.Add(str));
        }
        Console.WriteLine(String.Join(" ", result));

        result.Clear();
        foreach (var str in input)
        {
            result.Add(myList.Add(str));
        }
        Console.WriteLine(String.Join(" ", result));

        List<string> output = new List<string>();        
        for (int i = 0; i < counter; i++)
        {
            output.Add(arc.Remove(input[i]));
        }
        Console.WriteLine(String.Join(" ", output));

        output.Clear();
        for (int i = 0; i < counter; i++)
        {
            output.Add(myList.Remove(input[i]));
        }        
        Console.WriteLine(String.Join(" ", output));

    }
}
