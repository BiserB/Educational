using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int cnt = input.Length - 1;
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = 0; j < cnt; j++)
                {
                    input[j] += input[j + 1];
                }
                cnt--;
            }
            Console.WriteLine(input[0]);
        }
    }
}
