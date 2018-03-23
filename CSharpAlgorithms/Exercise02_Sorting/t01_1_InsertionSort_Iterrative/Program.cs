using System;
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
        for (int i = 1; i < arr.Length; i++)
        {
            int index = i;
            while (i > 0 && arr[index] < arr[index - 1])
            {
                Swap(index);
            }
        }
    }

    private static void Swap(int index)
    {
        int temp = arr[index];
        arr[index] = arr[index - 1];
        arr[index - 1] = temp;
    }
}
