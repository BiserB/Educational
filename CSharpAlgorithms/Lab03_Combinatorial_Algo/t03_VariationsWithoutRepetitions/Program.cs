using System;
using System.Linq;

public class Program
{
    private static string[] set;
    private static string[] variation;
    private static int length;
    private static bool[] used;
    private static int variationLength;

    static void Main()
    {
        set = Console.ReadLine().Split();

        length = set.Length;

        used = new bool[length];

        variationLength = int.Parse(Console.ReadLine());

        variation = new string[variationLength];       

        GenerateVariation(0);        
    }

    private static void GenerateVariation(int index)
    {
        if (index >= variationLength)
        {
            Print();
        }
        else
        {
            for (int i = 0; i < length; i++)
            {
                if (used[i] == false)
                {
                    variation[index] = set[i];
                    used[i] = true;
                    GenerateVariation(index + 1);
                    used[i] = false;
                }
            }
        }
    }

    private static void Print()
    {
        Console.WriteLine(string.Join(" ", variation));
    }
}
