using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Box<string>> list = new List<Box<string>>(n);

        for (int i = 0; i < n; i++)
        {
            string data = Console.ReadLine();
            Box<string> box = new Box<string>(data);
            list.Add(box);
        }

        string str = Console.ReadLine();
        Box<string> threshold = new Box<string>(str);

        int greater = Comparer<Box<string>>.Compare(list, threshold);

        Console.WriteLine(greater);
    }
}
