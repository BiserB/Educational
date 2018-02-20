using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Enter two integers n and k. Generate and print the following sequence of n elements:
//  The first element is: 1
//  All other elements = sum of the previous k elements (if less than k are available, sum all of them)
//  Example: n = 9, k = 5  -> 120 = 4 + 8 + 16 + 31 + 61

namespace SequenceOfNumbersSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] result = new int[n];
            result[0] = 1;
            
            for (int i = 1; i < n; i++)
            {
                int sum = 0;
                if (i < k)
                {
                    for (int j = 0; j < i; j++)
                    {
                        sum += result[j];
                    }
                }
                else
                {
                    for (int j = i-k; j < i; j++)
                    {
                        sum += result[j];
                    }
                }
                result[i] = sum ;
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
