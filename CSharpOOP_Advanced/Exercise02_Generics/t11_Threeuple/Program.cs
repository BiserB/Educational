using System;


public class Program
{
    static void Main(string[] args)
    {
        string[] line1 = Console.ReadLine().Split();
        string[] line2 = Console.ReadLine().Split();
        string[] line3 = Console.ReadLine().Split();

        string fullName = line1[0] + " " + line1[1];
        string address = line1[2];
        string town = line1[3];
        var person = new Threeuple<string, string, string>(fullName, address, town);

        string name = line2[0];
        int liters = int.Parse(line2[1]);
        bool drunk = false;
        if (line2[2].ToLower() == "drunk")
        {
            drunk = true;
        }
        var drinker = new Threeuple<string, int, bool>(name, liters, drunk);

        string client = line3[0];
        double amount = double.Parse(line3[1]);
        string bank = line3[2];
        var numbers = new Threeuple<string, double, string>(client, amount, bank);

        Console.WriteLine(person);
        Console.WriteLine(drinker);
        Console.WriteLine(numbers);
    }
}
