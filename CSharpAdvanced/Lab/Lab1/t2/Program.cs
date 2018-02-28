using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Stack<string> stack = new Stack<string>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }
            int result = int.Parse(stack.Pop());
            while (stack.Count() > 0)
            {
                string sign = stack.Pop();
                int element = int.Parse(stack.Pop());
                if (sign == "-")
                {
                    result -= element;
                }
                if (sign == "+")
                {
                    result += element;
                }
            }
            Console.WriteLine(result);
        }
    }
}
