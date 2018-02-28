using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace t10_2
{
    class Program
    {
        static void Main()
        {
            StringBuilder text = new StringBuilder();
            Stack<string> snapshots = new Stack<string>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                string command = input.Split(' ').First();
                string data = input.Split(' ').Last();
                if (command == "1")
                {
                    snapshots.Push(text.ToString());
                    text.Append(data);
                }
                else if (command == "2")
                {
                    snapshots.Push(text.ToString());
                    int count = int.Parse(data);
                    int startindex = text.Length - count;
                    text.Remove(startindex, count);
                }
                else if (command == "3")
                {
                    int index = int.Parse(data) - 1;
                    char ch = text[index];                    
                    Console.WriteLine(ch);
                }
                else if (command == "4")
                {
                    text.Clear();                    
                    string previous = snapshots.Pop();                    
                    text.Append(previous);
                    
                }
            }
        }
    }
}
