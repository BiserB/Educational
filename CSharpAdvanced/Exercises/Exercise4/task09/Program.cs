using System;
using System.Collections.Generic;
using System.Linq;

namespace task09
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnt = int.Parse(Console.ReadLine());
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();
            int divisor = 0;
            Predicate<int> nodivisible = (dividend) => dividend % divisor != 0;
            for (int i = 1; i <= cnt; i++)
            {
                bool divisible = true;
                foreach (int num in numbers)
                {
                    divisor = num;
                    if (nodivisible(i))
                    {
                        divisible = false;
                        break;
                    }
                }
                if (divisible)
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
