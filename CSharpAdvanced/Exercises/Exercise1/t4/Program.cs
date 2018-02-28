using System;
using System.Collections.Generic;
using System.Linq;

namespace t4
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(data);
            int n = input[0];
            int s = input[1];
            int x = input[2];
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }


        }
    }
}
