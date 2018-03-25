using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Box<int>> list = new List<Box<int>>(n);

        for (int i = 0; i < n; i++)
        {
            int data = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>(data);
            list.Add(box);
        }

        int[] indexes = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        int left = indexes[0];
        int right = indexes[1];

        Swaper<Box<int>>.Swap(list, left, right);

        foreach (Box<int> box in list)
        {
            Console.WriteLine(box);
        }
    }
}