using System;
using System.Collections.Generic;

namespace L3
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                             .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[][] grouped = new int[3][];
            List<int> list0 = new List<int>();
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            foreach (string num in input)
            {
                int n = int.Parse(num);
                int reminder = (Math.Abs(n)) % 3;
                
                switch (reminder)
                {
                    case 0:
                        list0.Add(n);
                        break;
                    case 1:
                        list1.Add(n);
                        break;
                    case 2:
                        list2.Add(n);
                        break;
                    default:
                        break;
                }
            }

            grouped[0] = new int[list0.Count];
            list0.CopyTo(grouped[0]);
            grouped[1] = new int[list1.Count];
            list1.CopyTo(grouped[1]);
            grouped[2] = new int[list2.Count];
            list2.CopyTo(grouped[2]);

            for (int i = 0; i < 3; i++)
            {
                foreach (var num in grouped[i])
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
