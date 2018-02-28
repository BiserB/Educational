using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
                queue.Enqueue(i);
            }

            Console.WriteLine("Stack = {0}", string.Join(' ',stack));
            Console.WriteLine("Stack peek= {0}", stack.Peek());
            Console.WriteLine("Stack[0]= {0}", stack.Pop());
            Console.WriteLine();
            Console.WriteLine("Queue = {0}", string.Join(' ',queue));
            Console.WriteLine("Queue peek= {0}", queue.Peek());
            Console.WriteLine("Queue[0] = {0}", queue.Dequeue());
        }
    }
}
