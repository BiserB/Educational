using System;


public class Program
{
    private static string[] set;
    private static string[] variation;
    private static int length;
    
    private static int variationLength;

    static void Main()
    {
        set = Console.ReadLine().Split();

        length = set.Length;        

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
                variation[index] = set[i];

                GenerateVariation(index + 1);                
            }
        }
    }

    private static void Print()
    {
        Console.WriteLine(string.Join(" ", variation));
    }
}
