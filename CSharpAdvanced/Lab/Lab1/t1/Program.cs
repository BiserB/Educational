using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input);
            int cnt = stack.Count;
            for (int i = 0; i < cnt; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
