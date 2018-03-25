using System;

public class Program
{
    static void Main()
    {
        Box<int> box = new Box<int>(5);
        Box<string> strBox = new Box<string>("life in a box");

        Console.WriteLine(box);
        Console.WriteLine(strBox);
    }
}
