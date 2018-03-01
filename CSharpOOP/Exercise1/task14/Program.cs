using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Dictionary<string, int> siamese = new Dictionary<string, int>();
        Dictionary<string, decimal> cymric = new Dictionary<string, decimal>();
        Dictionary<string, int> street = new Dictionary<string, int>();
        string input = "";
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split();
            string name = data[1];
            if (data[0] == "StreetExtraordinaire")
            {
                street[name] = int.Parse(data[2]);
            }
            else if (data[0] == "Siamese")
            {
                siamese[name] = int.Parse(data[2]);
            }
            else if (data[0] == "Cymric")
            {
                cymric[name] = decimal.Parse(data[2]);
            }
        }
        input = Console.ReadLine();
        if (street.ContainsKey(input))
        {
            Console.WriteLine($"StreetExtraordinaire {input} {street[input]}");
        }
        else if (siamese.ContainsKey(input))
        {
            Console.WriteLine($"Siamese {input} {siamese[input]}");
        }
        else if (cymric.ContainsKey(input))
        {
            Console.WriteLine($"Cymric {input} {cymric[input]:f2}");
        }
    }
}
