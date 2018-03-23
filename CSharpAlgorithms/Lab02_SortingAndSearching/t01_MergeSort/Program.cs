using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static int counter = 0;

    static void Main()
    {
        List<int> num = Console.ReadLine().Split().Select(int.Parse).ToList();

        List<int> sorted = Mergesorter.MergeSort(num);

        Console.WriteLine(string.Join(" ", sorted));

        Console.WriteLine(counter);
    }
    
}

public static class Mergesorter
{
    public static List<int> MergeSort(List<int> numbers)
    {
        if (numbers.Count <= 1)
        {
            return numbers;
        }

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (i % 2 != 0)
            {
                left.Add(numbers[i]);
            }
            else
            {
                right.Add(numbers[i]);
            }
        }

        left = MergeSort(left);
        right = MergeSort(right);

        return SortAndMerge(left, right);

    }

    private static List<int> SortAndMerge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();
        while (NotEmpty(left) && NotEmpty(right))
        {
            if (left.First() <= right.First())
            {
                result.Add(left.First());
                left.RemoveAt(0);
            }
            else
            {
                result.Add(right.First());
                right.RemoveAt(0);
                Program.counter++;
            }
        }

        if (NotEmpty(left))
        {
            result.Add(left.First());
            left.RemoveAt(0);
        }
        if (NotEmpty(right))
        {
            result.Add(right.First());
            right.RemoveAt(0);
            Program.counter++;
        }

        return result;
    }

    private static bool NotEmpty(List<int> list)
    {
        return list.Count > 0;
    }
}

