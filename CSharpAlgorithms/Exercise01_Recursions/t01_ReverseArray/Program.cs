using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Reverse(arr, arr.Length - 1);
    }

    private static void Reverse(int[] arr, int lastIndex)
    {
        if (lastIndex < 0)
        {
            return;
        }
        Console.Write(arr[lastIndex] + " ");
        Reverse(arr, lastIndex - 1);
    }
}