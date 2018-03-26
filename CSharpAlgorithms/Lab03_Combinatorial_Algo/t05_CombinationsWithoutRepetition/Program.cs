using System;

public class Program
{
    private static string[] set;
    private static string[] combination;
    private static int length;    
    private static int combLength;

    static void Main()
    {
        set = Console.ReadLine().Split();
        length = set.Length;

        combLength = int.Parse(Console.ReadLine());
        combination = new string[combLength];

        GenerateComabination(0, 0);
    }

    private static void GenerateComabination(int index, int start)
    {
        if (index >= combLength)
        {
            Print();
        }
        else
        {
            for (int i = start; i < length; i++)
            {
                combination[index] = set[i];
                GenerateComabination(index + 1, i + 1);
            }
        }
    }

    private static void Print()
    {
        Console.WriteLine(string.Join(" ", combination));
    }
}