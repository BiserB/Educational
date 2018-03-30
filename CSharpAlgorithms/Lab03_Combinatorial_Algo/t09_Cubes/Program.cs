using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        int[] digits = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Dictionary<int, int> elements = new Dictionary<int, int>();

        double f12 = 479001600;
        double f11 = 39916800;
        double f10 = 3628800;
        double f9 = 362880;
        double f8 = 40320;
        double f7 = 5040;
        double f6 = 720;
        double f5 = 120;
        double f4 = 24;
        double f3 = 6;
        double f2 = 2;
        double f1 = 1;


        for (int i = 0; i < 12; i++)
        {
            if (!elements.ContainsKey(digits[i]))
            {
                elements[digits[i]] = 0;
            }

            elements[digits[i]] += 1;
        }

    }
}
