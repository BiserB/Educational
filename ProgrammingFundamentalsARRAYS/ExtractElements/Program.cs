using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (input.Length == 1)
            {
                Console.WriteLine(input[0]);
            }
            else if (input.Length % 2 == 1)
            {
                int middle = input.Length / 2;
                Console.WriteLine("{0} {1} {2}", input[middle - 1], input[middle], input[middle + 1]);

            }
            else if (input.Length % 2 == 0)
            {
                int middle = input.Length / 2;
                Console.WriteLine("{0} {1}", input[middle - 1], input[middle]);

            }
        }
    }
}
