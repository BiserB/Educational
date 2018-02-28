using System;
using System.Collections.Generic;
using System.Linq;

namespace t6
{
    class Program
    {
        static void Main()
        {
            int cnt = int.Parse(Console.ReadLine());
            Queue<int> amounts = new Queue<int>();
            Queue<int> distances = new Queue<int>();
            Queue<int> result = new Queue<int>();
            for (int i = 0; i < cnt; i++)
            {
                int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                amounts.Enqueue(data[0]);
                distances.Enqueue(data[1]);
            }
            int tankAmount = 0;
            int nextDistance = 0;
            for (int i = 0; i < cnt; i++)
            {
                int a = amounts.Dequeue();
                amounts.Enqueue(a);
                int d = distances.Dequeue();
                distances.Enqueue(d);
                tankAmount += a;
                nextDistance += d;
                if (tankAmount >= nextDistance)
                {
                    result.Enqueue(i);
                }
                else
                {
                    result.Clear();
                    tankAmount = 0;
                    nextDistance = 0;
                }
            }
            Console.WriteLine(result.Peek());
        }
    }
}
