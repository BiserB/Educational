using System;
using System.Linq;

namespace task04
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            int low = numbers[0];
            int high = numbers[1];
            Predicate<int> even = i => i % 2 == 0;            
            Predicate<string> evenRequest = text => text == "even";
            for (int i = low; i <= high; i++)
            {
                if (evenRequest(input))
                {
                    if (even(i))
                    {
                        Console.Write(i + " ");
                    }                    
                }
                else
                {
                    if (!even(i))
                    {
                        Console.Write(i + " ");
                    }
                }
                    
            }
            
        }
    }
}
