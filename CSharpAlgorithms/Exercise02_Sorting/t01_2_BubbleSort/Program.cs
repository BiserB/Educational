using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int[] arr;

    static void Main()
    {
        arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Sort(arr);

        Console.WriteLine(string.Join(" ", arr));
    }

    private static void Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int index = i;
            Func<bool> indexInArr = () => index < arr.Length - 1;

            while (indexInArr() && arr[index] > arr[index + 1])
            {
                Swap(index);
                index++;
            }
        }
    }

    private static void Swap(int index)
    {
        int temp = arr[index];
        arr[index] = arr[index + 1];
        arr[index + 1] = temp;
    }
}