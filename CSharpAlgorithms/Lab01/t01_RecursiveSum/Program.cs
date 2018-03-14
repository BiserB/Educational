// Write a program that finds the sum of all elements in an integer array. Use recursion.

using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int result = FindSum(arr, 0);

        Console.WriteLine(result);
    }

    private static int FindSum(int[] arr, int index)
    {
        if (index == arr.Length - 1)
        {
            return arr[index];
        }
        else
        {
            return arr[index] + FindSum(arr, index + 1);
        }
        
    }
}
