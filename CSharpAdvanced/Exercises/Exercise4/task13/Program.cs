using System;
using System.Collections.Generic;
using System.Linq;

namespace task13
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<string> data = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
            Func<string, int> calc = word =>
            {
                int result = 0;
                foreach (char ch in word)
                {
                    result += ch;
                }
                return result;
            };
            Console.WriteLine(data.Where(w => calc(w) > num).FirstOrDefault());  
        }
    }
}
