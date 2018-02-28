using System;
using System.Collections.Generic;
using System.Linq;

namespace task10
{
    class Program
    {
        static void Main()
        {
            List<string> list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = "";
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (command[0])
                {
                    case "Remove":
                        Removing(list, command);
                        break;
                    case "Double":
                        Adding(list, command);
                        break;
                }
            }

            if (list.Count != 0)
            {
                Console.WriteLine(string.Join(", ", list) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        private static void Removing(List<string> list, string[] command)
        {
            if (command[1] == "StartsWith")
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].StartsWith(command[2]))
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            else if(command[1] == "EndsWith")
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].EndsWith(command[2]))
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            else if (command[1] == "Length")
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].Length == int.Parse(command[2]))
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            
        }
        private static void Adding(List<string> list, string[] command)
        {
            if (command[1] == "StartsWith")
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].StartsWith(command[2]))
                    {
                        list.Add(list[i]);
                    }
                }
            }
            else if (command[1] == "EndsWith")
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].EndsWith(command[2]))
                    {
                        list.Add(list[i]);
                    }
                }
            }
            else if (command[1] == "Length")
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].Length == int.Parse(command[2]))
                    {
                        list.Add(list[i]);
                    }
                }
            }

        }

    }
}
