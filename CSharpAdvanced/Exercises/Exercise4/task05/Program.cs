using System;
using System.Collections.Generic;
using System.Linq;

namespace task05
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new string[] { " "},StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToList();
            Func<int, int> add = i => i + 1;
            Func<int, int> subtract = i => i - 1 ;
            Func<int, int> multiply = i => i * 2;
            
            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = numbers.Select(n => add(n)).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => subtract(n)).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => multiply(n)).ToList();
                        break;
                    case "print":
                        Console.WriteLine(String.Join(" ", numbers)); ;
                        break;
                }

            }
            
        }
    }
}
