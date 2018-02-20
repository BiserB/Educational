using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// singer @venue ticketsPrice ticketsCount

namespace Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<singer>\w+ ?\w* ?\w*) @(?<venue>\w+ ?\w* ?\w*) (?<price>\d+) (?<count>\d+)$";
            string input = Console.ReadLine();
            var register = new Dictionary<string, Dictionary<string, int>>();
            while (input != "End")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Match m = Regex.Match(input, pattern);
                    string singer = m.Groups["singer"].Value;
                    string venue = m.Groups["venue"].Value;
                    int price = int.Parse(m.Groups["price"].Value);
                    int count = int.Parse(m.Groups["count"].Value);
                    int total = price * count;

                    if (!register.ContainsKey(venue))
                    {
                        register[venue] = new Dictionary<string, int>();
                    }
                    if (!register[venue].ContainsKey(singer))
                    {
                        register[venue][singer] = 0;
                    }
                    register[venue][singer] += total;
                }
                input = Console.ReadLine();
            }
            foreach (var entry in register)
            {
                Console.WriteLine(entry.Key);
                foreach (var item in entry.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", item.Key, item.Value);
                }
            }
        }
    }
}
