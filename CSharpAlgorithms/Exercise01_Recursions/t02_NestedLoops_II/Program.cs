using System;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Loop(arr, 0);
    }

    private static void Loop(int[] arr, int index)
    {
        if (index >= arr.Length)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        }
        InternalLoop(arr, index, 1);
    }

    private static void InternalLoop(int[] arr, int index, int i)
    {
        if (i > arr.Length)
        {
            return;
        }
        arr[index] = i;
        Loop(arr, index + 1);
        InternalLoop(arr, index, i + 1);
    }
}
