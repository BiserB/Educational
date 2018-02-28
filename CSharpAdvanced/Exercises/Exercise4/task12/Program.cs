using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace task12
{
    class Program
    {
        public static List<int> gems = new List<int>();
        public static List<int> removed = new List<int>();

        static void Main()
        {
            List<int> data = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToList();
            gems.AddRange(data);
            
            string input = "";
            while ((input = Console.ReadLine()) != "Forge")
            {
                string[] command = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                string property = command[1];
                int parameter = int.Parse(command[2]);
                switch (property)
                {
                    case "Sum Left":
                        Operation(action, (left, x, right) => left + x  == parameter);
                        break;
                    case "Sum Right":
                        Operation(action, (left, x, right) => x + right == parameter);
                        break;
                    case "Sum Left Right":
                        Operation(action, (left, x, right) => left + x + right == parameter);
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", gems.Where(g => !removed.Contains(g))));
        }

        private static void Operation(string action, Func<int, int, int, bool> check)
        {           
            
            for (int i = 0; i < gems.Count; i++)
            {
                int x = gems[i];
                int left = 0;
                int right = 0;
                if (i == 0)
                {
                    left = 0;
                }
                else
                {
                    left = gems[i - 1];
                }
                if (i >= gems.Count - 1)
                {
                    right = 0;
                }
                else
                {
                    right = gems[i + 1];
                }

                if (check(left, x, right))
                {
                    if (action == "Exclude")
                    {
                        removed.Add(gems[i]);
                    }
                    else if (action == "Reverse")
                    {
                        removed.Remove(gems[i]);
                    }
                }
            }
                
            
        }
    }
}
