using System;
using System.Collections.Generic;

namespace t06_GenericCountMethod_Doubles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> list = new List<Box<double>>(n);

            for (int i = 0; i < n; i++)
            {
                double data = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(data);
                list.Add(box);
            }

            double d = double.Parse(Console.ReadLine());
            Box<double> threshold = new Box<double>(d);

            int greater = Comparer<Box<double>>.Compare(list, threshold);

            Console.WriteLine(greater);
        }
    }
}
