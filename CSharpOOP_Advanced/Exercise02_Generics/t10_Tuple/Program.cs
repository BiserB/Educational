using System;

public class Program
{
    static void Main()
    {
        string[] line1 = Console.ReadLine().Split();
        string[] line2 = Console.ReadLine().Split();
        string[] line3 = Console.ReadLine().Split();

        string fullName = line1[0] + " " + line1[1];
        string address = line1[2];
        var person = new MyTuple<string, string>(fullName, address);

        string name = line2[0];
        int liters = int.Parse(line2[1]);
        var drinker = new MyTuple<string, int>(name, liters);
        
        int num1 = int.Parse(line3[0]);
        double num2 = double.Parse(line3[1]);
        var numbers = new MyTuple<int, double>(num1, num2);

        Console.WriteLine(person);
        Console.WriteLine(drinker);
        Console.WriteLine(numbers);

    }
}
