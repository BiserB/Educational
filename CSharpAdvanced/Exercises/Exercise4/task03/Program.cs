using System;
using System.Linq;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();

            Func<int[], int> minNum = arr => 
            {
                int min = int.MaxValue;
                foreach (var num in arr)
                {
                    if (min > num)
                    {
                        min = num;
                    }
                };
                return min;
            };

            Console.WriteLine(minNum(input));
        }
    }
}
