using System;


public class Program
{
    static void Main()
    {
        string[] data = Console.ReadLine().Split('/');

        int p = int.Parse(data[0]);
        int q = int.Parse(data[1]);

        PrintEgyptianFractions(p, q);
    }

    private static void PrintEgyptianFractions(int p, int q)
    {
        // If either numerator or denominator is 0
        if (p == 0 || q == 0)
        {
            return;
        }

        // If numerator divides denominator, then simple division
        // makes the fraction in 1/n form
        if (p % q == 0)
        {
            Console.Write($" 1/{p/q}");
            return;
        }

        // If denominator divides numerator, then the given number
        // is not fraction
        if (q % p == 0)
        {
            Console.Write($" {p/q}");
            return;
        }

        // If numerator is more than denominator
        if (p > q)
        {
            Console.Write($" {p / q}");
            PrintEgyptianFractions(p % q, q);
            return;
        }

        // We reach here q > p and q % p is non-zero
        // Find ceiling of q/p and print it as first
        // fraction

        int n = q / p + 1;
        Console.Write($" 1/{n}");

        PrintEgyptianFractions(p * n - q, q * n);
    }
}
