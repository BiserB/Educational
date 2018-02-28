using System;
using System.Collections.Generic;
using System.Linq;

namespace t7_II
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            List<List<int>> first = new List<List<int>>();
            List<List<int>> second = new List<List<int>>();
            for (int r = 0; r < rows; r++)
            {
                List<int> list = Console.ReadLine()
                          .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToList();
                first.Add(list);
            }
            for (int r = 0; r < rows; r++)
            {
                List<int> list = Console.ReadLine()
                          .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToList();
                second.Add(list);
            }
            bool match = true;
            int count = first[0].Count + second[0].Count;
            for (int r = 1; r < rows ; r++)
            {
                count += first[r].Count + second[r].Count;
                if (first[r].Count + second[r].Count != first[r - 1].Count + second[r - 1].Count)
                {
                    match = false;
                }
            }
            if (match)
            {
                for (int r = 0; r < rows; r++)
                {
                    string a = String.Join(", ", first[r]);
                    second[r].Reverse();
                    string b = String.Join(", ", second[r]);
                    Console.Write("[" + a + ", " + b + "]");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {count}");
            }
        }
    }
}
