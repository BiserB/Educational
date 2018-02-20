using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Read a list of real numbers and print largest 3 of them.
//  If less than 3 numbers exit, print all of them.

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            input.Sort();
            input.Reverse();
            if (input.Count > 3)
            {
                List<double> result = input.Take(3).ToList();
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine(string.Join(" ", input));
            }
        }
    }
}
