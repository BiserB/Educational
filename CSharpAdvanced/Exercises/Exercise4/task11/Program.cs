using System;
using System.Collections.Generic;
using System.Linq;

namespace task11
{
    class Program
    {
        public static Dictionary<string, List<string>> filters = new Dictionary<string, List<string>>
        {
            ["Starts with"] = new List<string>(),
            ["Ends with"] = new List<string>(),
            ["Length"] = new List<string>(),
            ["Contains"] = new List<string>()
        };

        static void Main()
        {
            List<string> list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            string input = "";
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] command = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string operation = command[0];
                string property = command[1];
                string parameter = command[2];

                ChangeFilter(operation, property, parameter);
                
            }
            int length = list.Count;
            for (int i = 0; i < length; i++)
            {                
                foreach (var f in filters["Starts with"])
                {
                    if (list[i].StartsWith(f))
                    {
                        list.RemoveAt(i);
                        length--;
                    }
                }
                foreach (var f in filters["Ends with"])
                {
                    if (list[i].EndsWith(f))
                    {
                        list.RemoveAt(i);
                        length--;
                    }
                }
                foreach (var f in filters["Length"])
                {
                    if (list[i].Length == int.Parse(f))
                    {
                        list.RemoveAt(i);
                        length--;
                    }
                }
                foreach (var f in filters["Contains"])
                {
                    if (list[i].Contains(f))
                    {
                        list.RemoveAt(i);
                        length--;
                    }
                }
            }
            Console.WriteLine(String.Join(" ", list));
        }

        private static void ChangeFilter(string operation, string property, string parameter)
        {
            if (operation == "Add filter")
            {
                filters[property].Add(parameter);
            }
            else if (operation == "Remove filter")
            {
                filters[property].Remove(parameter);
            }
            
        }
    }
}
