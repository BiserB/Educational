using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trainlands
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimiter = new char[] {' ', '-', ':', '>', '=' };
            string addRemove = @"\w+ -> \w+";
            string copy = @"\w+ = \w+";
            var trains = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "It's Training Men!")
            {
                string trainName = "";
                string wagon = "";
                int power = 0;
                string othername = "";

                string[] data = input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                trainName = data[0];

                if (data.Length == 3)
                {                    
                    wagon = data[1];
                    power = int.Parse(data[2]);
                    if (!trains.ContainsKey(trainName))
                    {
                        trains[trainName] = new Dictionary<string, int>();
                    }
                    trains[trainName][wagon] = power;
                }
                else
                {
                    if (Regex.IsMatch(input, addRemove))
                    {                        
                        othername = data[1];
                        if (!trains.ContainsKey(trainName))
                        {
                            trains[trainName] = new Dictionary<string, int>();
                        }
                        foreach (var wag in trains[othername])
                        {
                            trains[trainName][wag.Key] = wag.Value;
                        }
                        trains.Remove(othername);
                    }
                    else if (Regex.IsMatch(input, copy))
                    {
                        othername = data[1];
                        if (!trains.ContainsKey(trainName))
                        {
                            trains[trainName] = new Dictionary<string, int>();
                        }
                        trains[trainName] = trains[othername];
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var train in trains
                .OrderByDescending(p => p.Value.Values.Sum())
                .ThenBy(p => p.Value.Count))
            {
                Console.WriteLine("Train: {0}", train.Key);
                foreach (var wagon in train.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine("###{0} – {1}", wagon.Key, wagon.Value);
                }
            }
        }
    }
    
}
