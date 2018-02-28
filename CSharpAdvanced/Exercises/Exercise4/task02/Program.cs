using System;

namespace task02
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
                    Console.WriteLine("Sir " + item);
                };
            };

            print(input);
        }
    }
}
