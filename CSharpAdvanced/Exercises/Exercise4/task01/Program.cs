using System;

namespace task01
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Action<string[]> print = textLine =>
            {
                foreach (var item in textLine)
                {
                    Console.WriteLine(item);
                };
            };

            print(input);
        }
    }
}
