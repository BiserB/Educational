using System;
using System.Linq;

namespace L2
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(n => int.Parse(n))
                                .ToArray();                               
            
            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
