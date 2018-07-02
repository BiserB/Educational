using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmailStatistic
{
    internal class Program
    {
        private static void Main()
        {
            string pattern = @"^(?<user>[A-Za-z]{5,})@(?<domain>([a-z]{3,}).(bg|com|org))$";

            Dictionary<string, List<string>> emailData = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string email = Console.ReadLine();
                Match match = Regex.Match(email, pattern);

                if (match.Success)
                {
                    string user = match.Groups["user"].Value;
                    string domain = match.Groups["domain"].Value;

                    if (!emailData.ContainsKey(domain))
                    {
                        emailData[domain] = new List<string>();
                    }

                    if (!emailData[domain].Contains(user))
                    {
                        emailData[domain].Add(user);
                    }
                }
            }

            foreach (var pair in emailData.OrderByDescending(p => p.Value.Count))
            {
                Console.WriteLine($"{pair.Key}:");
                foreach (var user in pair.Value)
                {
                    Console.WriteLine($"### {user}");
                }
            }
        }
    }
}