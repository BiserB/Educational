using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int number = int.Parse(Console.ReadLine());

        //int result = LinearSearch(arr, number);

        int result = BinarySearch(arr, number);

        Console.WriteLine(result);

    }

    private static int BinarySearch(int[] arr, int number)
    {
        int min = 0;
        int max = arr.Length - 1;
        while (min <= max)
        {
            int mid = (min + max) / 2;
            if (number == arr[mid])
            {
                return mid;
            }
            else if (number < arr[mid])
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }
        return -1;
    }

    private static int LinearSearch(int[] arr, int number)
    {
        int result = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == number)
            {
                result = i;
                break;
            }
        }
        return result;
    }
}
