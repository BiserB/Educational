// You are given a geometric figure box with parameters length,width and height. 
// Model a class Box that that can be instantiated by the same three parameters. 
// Expose to the outside world only methods for its surface area, lateral surface area and its volume

using System;

public class Program
{
    static void Main()
    {
        decimal length = decimal.Parse(Console.ReadLine());
        decimal width = decimal.Parse(Console.ReadLine());
        decimal height = decimal.Parse(Console.ReadLine());

        Box myBox = new Box(length, width, height);

        Console.WriteLine($"Surface Area - {myBox.SurfaceArea():f2}");
        Console.WriteLine($"Lateral Surface Area - {myBox.LateralSurfaceArea():f2}");
        Console.WriteLine($"Volume - {myBox.Volume():f2}");
    }
}

