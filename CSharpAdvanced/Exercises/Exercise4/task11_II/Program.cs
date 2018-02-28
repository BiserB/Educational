using System;
using System.Collections.Generic;
using System.Linq;

namespace task11_II
{
    class Program
    {
        public static List<string> list = new List<string>();
        public static List<string> removed = new List<string>();

        static void Main()
        {
            List<string> data = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            list.AddRange(data);
            string input = "";
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] command = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                string property = command[1];
                string parameter = command[2];

                switch (property)
                {
                    case "Starts with":
                        Operate(action, x => x.StartsWith(parameter));
                        break;
                    case "Ends with":
                        Operate(action, x => x.EndsWith(parameter));
                        break;
                    case "Length":
                        int length = int.Parse(parameter);
                        Operate(action, x => x.Length == length);
                        break;
                    case "Contains":
                        Operate(action, x => x.Contains(parameter));
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", list.Where(n => !removed.Contains(n))));          

        }

        private static void Operate(string action, Func<string, bool> check)
        {
            if (action == "Add filter")
            {
                foreach (string name in list)
                {
                    if (check(name))
                    {
                        removed.Add(name);
                    }
                }
            }
            else if (action == "Remove filter")
            {
                for (int i = 0; i < removed.Count; i++)
                {
                    if (check(removed[i]))
                    {
                        removed.RemoveAt(i);
                    }
                }                
            }
        }
    }
}
