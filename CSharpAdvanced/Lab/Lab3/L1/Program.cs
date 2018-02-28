using System;
using System.Linq;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " },StringSplitOptions.RemoveEmptyEntries)
                                .Select(n => int.Parse(n))
                                .Where(n => n % 2 == 0)
                                .OrderBy(n => n)
                                .ToArray();
            string result = String.Join(", ", numbers);
            Console.WriteLine(result);
        }
    }
}
