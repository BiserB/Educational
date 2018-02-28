using System;

namespace t8
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            long a = 1;
            long b = 1;
            long fib = 0;
            if (num > 2)
            {
                for (int i = 0; i < num - 2; i++)
                {
                    fib = a + b;
                    a = b;
                    b = fib;
                }
                Console.WriteLine(fib);
            }
            else
            {
                Console.WriteLine("1");
            }
        }
    }
}
