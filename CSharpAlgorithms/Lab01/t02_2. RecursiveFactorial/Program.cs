// Write a program that finds the factorial of a given number. Use recursion.

using System;

public class Program
{
    static void Main()
    {
        double num = double.Parse(Console.ReadLine());

        double result = Factorial(num);

        Console.WriteLine(result);
    }

    static double Factorial(double num)
    {
        if (num == 0)
        {
            return 1;
        }

        double factorial = num * Factorial(num - 1);
        return factorial;
    }
}
