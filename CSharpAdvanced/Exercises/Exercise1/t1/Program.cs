using System;
using System.Collections.Generic;

namespace t1
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Trim().Split(' ');
            Stack<string> stack = new Stack<string>(input);
            while (stack.Count > 0)
            {
                string s = stack.Pop();
                Console.Write($"{s} ");
            }

            
        }
    }
}
