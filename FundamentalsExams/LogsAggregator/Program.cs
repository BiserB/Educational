using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            var register = new Dictionary<string, Dictionary<string, int>>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                string address = data[0];
                string user = data[1];
                int duration = int.Parse(data[2]);
                if (!register.ContainsKey(user))
                {
                    register[user] = new Dictionary<string, int>();
                }
                if (!register[user].ContainsKey(address))
                {
                    register[user][address] = 0;
                }
                register[user][address] += duration;
            }
            foreach (var user in register.OrderBy(p => p.Key))
            {
                int total = user.Value.Values.Sum();
                Console.WriteLine("{0}: {1} [{2}]", user.Key, total, string.Join(", ", user.Value.Keys.OrderBy(p => p)));
            } 
        }
    }
}
