using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// program to read an array of integers and find all triples of elements a, b and c,
// such that a + b == c (where a stays to the left from b).
// Print “No” if no such triples exist.

namespace TripleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool match = false;
            for (int i = 0; i < input.Length - 1; i++)
            {
                int a = input[i];
                for (int j = i + 1; j < input.Length; j++)
                {
                    int b = input[j];
                    for (int k = 0; k < input.Length; k++)
                    {
                        int c = input[k];
                        if (a + b == c)
                        {
                            Console.WriteLine("{0} + {1} == {2}", a, b, c);
                            match = true;
                        }
                    }
                }
            }
            if (!match)
            {
                Console.WriteLine("No");
            }
        }
    }
}
