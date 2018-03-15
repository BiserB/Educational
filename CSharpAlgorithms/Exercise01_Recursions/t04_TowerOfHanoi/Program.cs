using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static Stack<int> source;
    private static Stack<int> dest;
    private static Stack<int> aux;
    private static int disks = 0;
    private static int steps = 0;

    static void Main()
    {
        Initialize();

        PrintRods();

        Move(disks, source, dest, aux);
    }

    private static void Initialize()
    {
        disks = int.Parse(Console.ReadLine());

        source = new Stack<int>();
        dest = new Stack<int>();
        aux = new Stack<int>();

        for (int i = disks; i > 0; i--)
        {
            source.Push(i);
        }        
    }

    private static void Move(int disk, Stack<int> source, Stack<int> dest, Stack<int> aux)
    {
        if (disk == 1)
        {            
            int topDisk = source.Pop();
            dest.Push(topDisk);
            PrintSteps(++steps);            
        }
        else
        {
            Move(disk - 1, source, aux, dest);

            dest.Push(source.Pop());
            PrintSteps(++steps);

            Move(disk - 1, aux, dest, source);
        }
    }

    private static void PrintSteps(int step)
    {
        Console.WriteLine($"Step #{step}: Moved disk");
        PrintRods();
    }

    private static void PrintRods()
    {
        Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
        Console.WriteLine("Destination: {0}", string.Join(", ", dest.Reverse()));
        Console.WriteLine("Spare: {0}", string.Join(", ", aux.Reverse()));
        Console.WriteLine();
    }
}