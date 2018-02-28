using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t3
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Stack<int> stack = new Stack<int>();
                do
                {
                    int reminder = input % 2;
                    input = input / 2;
                    stack.Push(reminder);
                }
                while (input != 0);
                foreach (var item in stack)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }
    }
}
