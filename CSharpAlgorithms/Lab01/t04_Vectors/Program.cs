// Generate all n-bit vectors of zeroes and ones in lexicographic order.

using System;

public class Program
{    
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] vector = new int[n];

        Generator(vector, 0);
    }

    private static void Generator(int[] vector, int index)
    {
        if (index == vector.Length)
        {
            PrintVector(vector);
            return;
        }
        for (int value = 0; value <= 1; value++)
        {
            vector[index] = value;
            Generator(vector, index + 1);
        }
    }

    private static void PrintVector(int[] vector)
    {
        foreach (var digit in vector)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
    }
}