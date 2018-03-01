// Problem 3. Ferrari
// Model an application which contains a class Ferrari and an interface.

using System;


public class StartUp
{
    static void Main()
    {
        string driverName = Console.ReadLine();
        ICar ferrari = new Ferrari(new Driver(driverName));
        Console.WriteLine(ferrari);
    }
}
