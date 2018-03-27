using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
                               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries )
                               .Select(int.Parse)
                               .ToArray();

        List<int> oddNumbers = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(numbers[i] + ", ");
            }
            else
            {
                oddNumbers.Add(numbers[i]);
            }
        }
        oddNumbers.Reverse();
        Console.WriteLine(string.Join(", ", oddNumbers));
    }
}
