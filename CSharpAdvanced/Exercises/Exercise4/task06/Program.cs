using System;
using System.Collections.Generic;
using System.Linq;

namespace task06
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divisor = int.Parse(Console.ReadLine());
            Predicate<int> nodivisible = (dividend) => dividend % divisor != 0;
            numbers.Reverse();
            Console.WriteLine(String.Join(" ", numbers.Where(n => nodivisible(n))));
        }
    }
}
