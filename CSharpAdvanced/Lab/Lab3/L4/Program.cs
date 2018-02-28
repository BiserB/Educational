using System;
using System.Linq;

namespace L4
{
    class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(n => double.Parse(n)) 
                                .Select(n => n * 1.2)
                                .ToArray();
            foreach (var item in numbers)
            {
                Console.WriteLine("{0:0.00}", item);
            }
            
        }
    }
}
