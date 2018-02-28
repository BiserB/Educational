using System;
using System.Collections.Generic;
using System.Linq;

namespace t2
{
    class Program
    {
        static void Main()
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> data = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int n = input[0];
            int s = input[1];
            int x = input[2];
            int index = data.Count - s;
            data.RemoveRange(index, s);

            if (data.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (data.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(data.Min());
                }
            }

        }
    }
}
