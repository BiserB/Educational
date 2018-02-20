using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Write a program to read n integers and print their 
// sum, min, max, first, last and average values.

namespace SumMinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] list = new int[num];
            for (int i = 0; i < num; i++)
            {
                int element = int.Parse(Console.ReadLine());
                list[i] = element;
            }
            Console.WriteLine("Sum = {0}", list.Sum());
            Console.WriteLine("Min = {0}", list.Min());
            Console.WriteLine("Max = {0}", list.Max());
            Console.WriteLine("Average = {0}", list.Average());
            Console.WriteLine("First = {0}", list.First());
            Console.WriteLine("Last = {0}", list.Last());
        }
    }
}
