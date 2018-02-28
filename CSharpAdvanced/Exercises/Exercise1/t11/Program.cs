using System;
using System.Collections.Generic;


namespace t11
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnt = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Trim().Split(' ');
            Queue<int> register = new Queue<int>();
            foreach (string num in input)
            {
                int n = int.Parse(num);
                register.Enqueue(n);
            }
           

            for (int i = 1; i <= cnt; i++)
            {
                int numberOfPlants = register.Count;
                int a = register.Dequeue();
                int b = 0;
                register.Enqueue(a);
                for (int j = 1; j < numberOfPlants; j++)
                {
                    b = register.Dequeue();
                    if (a >= b)
                    {
                        register.Enqueue(b);
                    }
                    a = b;
                }
                if (numberOfPlants == register.Count)
                {
                    Console.WriteLine(i - 1);
                    break;
                }
            }

        }
    }
}
