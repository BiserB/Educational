using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<int> num = Console.ReadLine().Split().Select(int.Parse).ToList();

        List<int> sorted = Mergesorter.MergeSort(num);

        Console.WriteLine(string.Join(" ", sorted));
    }
    
}
