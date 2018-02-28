using System;
using System.Collections.Generic;
using System.Linq;

namespace t11_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnt = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            var survivedIndexes = new Stack<int>();

            survivedIndexes.Push(0);                        // first plant always survive      

            var days = new int[cnt];                        // keep track of days untill plant die

            for (int i = 1; i < cnt; i++)
            {
                var maxDays = 0;
                int previous = plants[survivedIndexes.Peek()];
                int current = plants[i];

                while (survivedIndexes.Count > 0 && previous >= current)
                {
                    maxDays = Math.Max(maxDays, days[survivedIndexes.Pop()]);
                }

                if (survivedIndexes.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                survivedIndexes.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
