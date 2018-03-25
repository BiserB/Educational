using System;
using System.Collections.Generic;
using System.Linq;

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

        int[] indexes = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        int left = indexes[0];
        int right = indexes[1];

        Swaper<Box<string>>.Swap(list, left, right);
        
        foreach (Box<string> box in list)
        {
            Console.WriteLine(box);
        }
    }
}
