using System;
using System.Collections.Generic;
using System.Linq;

namespace task08
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Predicate<int> even = i => i % 2 == 0;
            numbers.Sort();
            Console.Write(string.Join(" ", numbers.Where(n => even(n))) + " ");
            Console.WriteLine(string.Join(" ", numbers.Where(n => !even(n))) );
        }
    }
}
