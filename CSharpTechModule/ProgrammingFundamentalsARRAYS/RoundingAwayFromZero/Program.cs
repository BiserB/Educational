using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  program to read an array of real numbers
//  round them to the nearest integer in “away from 0” style
//  and print the output as in the examples below.
//  2.9 -> 3;  -1.75 -> -2

namespace RoundingAwayFromZero
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                double num = input[i];
                //   if (num >= 0)
                //   {
                //       int result = (int)(num + 0.5);
                //       Console.WriteLine("{0} => {1}", num, result);
                //   }
                //   else
                //   {
                //       int result = (int)(num - 0.5);
                //       Console.WriteLine("{0} => {1}", num, result);
                //   }        

                double result = Math.Round(num, 0, MidpointRounding.AwayFromZero);
                Console.WriteLine("{0} => {1}", num, result);
            }
        }
    }
}
