// Generate all n choose k combinations. Read the set of elements, then number of elements to choose.

using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        int[] set = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int num = int.Parse(Console.ReadLine());

        int[] result = new int[num];
        int index = 0;
        int next = 0;

        Generator(set, result, index, next);
    }

    private static void Generator(int[] set, int[] result, int index, int next)
    {
        if (index == result.Length)
        {
            PrintResult(result);
        }
        else
        {
            for (int i = next; i < set.Length; i++)
            {
                result[index] = set[i];
                Generator(set, result, index + 1, i + 1);
            }
        }
    }

    private static void PrintResult(int[] vector)
    {
        foreach (var digit in vector)
        {
            Console.Write($"{digit} "); 
        }
        Console.WriteLine();
    }
}
