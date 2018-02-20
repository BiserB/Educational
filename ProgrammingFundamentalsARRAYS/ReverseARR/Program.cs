using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseARR
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int index = input.Length - 1;
            string[] result = new string[input.Length];
            int n = 0;
            for (int i = index; i >= 0; i--)
            {
                result[n] = input[i];
                n++;
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
