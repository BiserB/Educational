using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().ToLower().Split().ToArray();
            var result = new Dictionary<string, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!result.ContainsKey(input[i]))
                {
                    result[input[i]] = 0;
                }
                result[input[i]]++;
            }
            result = result.Where(p => p.Value % 2 == 1).ToDictionary(p => p.Key, p => p.Value);
            
            Console.WriteLine(string.Join(", ", result.Keys));
        }
    }
}
