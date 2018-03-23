using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {

    }

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
        }

        return result;
    }

    private static bool NotEmpty(List<int> list)
    {
        return list.Count > 0;
    }

}
