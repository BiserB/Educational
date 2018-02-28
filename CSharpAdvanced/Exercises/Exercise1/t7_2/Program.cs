using System;
using System.Collections.Generic;
using System.Linq;

namespace t7_2
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }
            char[] opening = new char[] { '(', '[', '{' };
            char closing = ' ';
            Stack<char> register = new Stack<char>();

            foreach (var ch in input)
            {
                if (opening.Contains(ch))
                {
                    register.Push(ch);
                }
                else
                {                    
                    if (ch == ')')
                    {
                        closing = '(';
                    }
                    else if (ch == ']')
                    {
                        closing = '[';
                    }
                    else if (ch == '}')
                    {
                        closing = '{';
                    }
                    if (register.Count > 0 && register.Peek() == closing)
                    {
                        register.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }                
            }
            if (register.Count > 0)
            {
                Console.WriteLine("NO");                
            }
            else
            {
                Console.WriteLine("YES");
            }

        }
    }
}
