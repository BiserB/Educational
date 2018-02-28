using System;
using System.Collections.Generic;
using System.Linq;

namespace t10
{
    class Program
    {
        static Stack<char> text = new Stack<char>();           //-- this is working stack
        static Stack<string> snapshots = new Stack<string>();  //-- there is stored all states of "text" stack  

        static void Main()
        {                      
            int num = int.Parse(Console.ReadLine());        //-- number of received commands
            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();          //-- read the input
                string command = input.Split(' ').First();  //-- read the type of command
                string data = input.Split(' ').Last();      //-- 
                if (command == "1")
                {
                    GetSnapshot();
                    foreach (var ch in data)
                    {
                        text.Push(ch);
                    }                    
                }
                else if (command == "2")
                {
                    GetSnapshot();
                    int count = int.Parse(data);
                    for (int j = 0; j < count; j++)
                    {
                        text.Pop();
                    }
                }
                else if (command == "3")
                {
                    int index = text.Count - int.Parse(data);
                    char element = text.ElementAt(index);
                    Console.WriteLine(element);
                }
                else if (command == "4")
                {                    
                    text.Clear();                    
                    string previous = snapshots.Pop();
                    foreach (var ch in previous)
                    {
                        text.Push(ch);
                    }
                }
            }

        }
        static void GetSnapshot()
        {
            string snapshot = "";
            int cnt = text.Count();
            if (text.Count > 0)
            {
                for (int j = cnt - 1; j >= 0; j--)
                {
                    snapshot += text.ElementAt(j);
                }
            }
            snapshots.Push(snapshot);
        }
    }
}
