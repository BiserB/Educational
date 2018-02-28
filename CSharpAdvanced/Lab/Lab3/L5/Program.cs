using System;
using System.Collections.Generic;
using System.Linq;

namespace L5
{
    class Program
    {        
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> register = new Dictionary<string, int>();            

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int personAge = int.Parse(data[1]);
                register[name] = personAge;
            }
            string type = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();  

            if (type == "older")
            {
                Dictionary<string, int> reg = register.Where(r => r.Value >= age).ToDictionary(r => r.Key, r => r.Value);
                Print(format, reg);
            }
            else if (type == "younger")
            {
                Dictionary<string, int> reg = register.Where(r => r.Value < age).ToDictionary(r => r.Key, r => r.Value);
                Print(format, reg);
            }
        }      
        private static void Print(string format,  Dictionary<string, int> reg)
        {
            if (format == "name")
            {
                reg.Select(r => r.Key).ToList().ForEach(r => Console.WriteLine(r));
            }
            else if (format == "age")
            {
                reg.Select(r => r.Value).ToList().ForEach(r => Console.WriteLine(r));
            }
            else
            {
                reg.Select(r => r).ToList().ForEach(r => Console.WriteLine($"{r.Key} - {r.Value}"));
            }
        }
    }
}
