using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  program, which receives an array of integers and an integer as input.
//  Find the last occurrence of the integer in the given array 
//  and print the sum of all elements before the number.

namespace GrabAndGo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());
            if (data.Contains(num))
            {
                int index = Array.LastIndexOf(data, num);
                int sum = 0;
                for (int i = 0; i < index; i++)
                {
                    sum += data[i];
                }
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}
