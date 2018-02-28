using System;
using System.Collections.Generic;

namespace t5
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());

            Queue<long> result = new Queue<long>();            
            Queue<long> helper = new Queue<long>();

            result.Enqueue(num);            

            while (result.Count < 50)
            {
                long a = num + 1;
                long b = 2 * num + 1;
                long c = num + 2;

                result.Enqueue(a);                
                helper.Enqueue(a);
                result.Enqueue(b);
                helper.Enqueue(b);
                result.Enqueue(c);
                helper.Enqueue(c);

                num = helper.Dequeue() ;
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(result.Dequeue() + " ");
            }

        }
    }
}
