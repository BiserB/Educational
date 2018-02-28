using System;
using System.Collections.Generic;
using System.Linq;

namespace t7
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Queue<char> opening = new Queue<char>();
            Queue<char> closing = new Queue<char>();
            bool balanced = true;
            foreach (char ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    opening.Enqueue(ch);
                }
                else if (ch == ')')
                {
                    closing.Enqueue('(');
                }
                else if (ch == '}')
                {
                    closing.Enqueue('{');
                }
                else if (ch == ']')
                {
                    closing.Enqueue('[');
                }
            }
            int countOfOpening = opening.Count;
            int countOfClosing = closing.Count;
            if (countOfOpening != countOfClosing)
            {
                balanced = false;
            }
            else
            {
                Queue<char> reversed = new Queue<char>(closing.Reverse());
                for (int i = 0; i < countOfOpening; i++)
                {
                    if (opening.Dequeue() != reversed.Dequeue())
                    {
                        balanced = false;
                        break;
                    }
                }
            }
            if (balanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
