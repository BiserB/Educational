using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Email_Statistics
{
    public static void Main()
    {
        string emailPattern = @"(?<username>[a-zA-Z]{5,})@(?<domain>(?<mailServer>[a-z]{3,}).(com|bg|org))";

        Dictionary<string, List<string>> emails = new Dictionary<string, List<string>>();

        int emailsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < emailsCount; i++)
        {
            string email = Console.ReadLine();

            Match match = Regex.Match(email, emailPattern);

            if (match.Success)
            {
                string domain = match.Groups["domain"].Value;
                string username = match.Groups["username"].Value;

                if (!emails.ContainsKey(domain))
                {
                    emails[domain] = new List<string>();
                }

                if (!emails[domain].Contains(username))
                {
                    emails[domain].Add(username);
                }
            }
        }

        foreach (var email in emails.OrderByDescending(x => x.Value.Count))
        {
            string domain = email.Key;
            List<string> usernames = email.Value;

            Console.WriteLine($"{domain}:");

            foreach (string username in usernames)
            {
                Console.WriteLine($"### {username}");
            }
        }
    }
}