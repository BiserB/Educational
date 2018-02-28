using System;
using System.Collections.Generic;

namespace t3
{
    class Program
    {
        static void Main(string[] args)
        {

            int cnt = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var trackMax = new Stack<int>();
            for (int i = 0; i < cnt; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                string command = data[0];
                if (command == "1")
                {
                    int number = int.Parse(data[1]);
                    stack.Push(number);
                    if (trackMax.Count == 0)
                    {
                        trackMax.Push(number);
                    }
                    else
                    {
                        if (trackMax.Peek() < number)
                        {
                            trackMax.Push(number);
                        }
                        else
                        {
                            trackMax.Push(trackMax.Peek());
                        }
                    }
                }
                else if (command == "2")
                {
                    stack.Pop();
                    trackMax.Pop();
                }
                else
                {
                    Console.WriteLine(trackMax.Peek());
                }
            }

        }
    }
}
