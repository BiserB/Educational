using System;
using System.Collections.Generic;

class Program
{
    private static string[] set;    
    private static int length;

    static void Main()
    {
        set = Console.ReadLine().Split();
        length = set.Length;
        
        GeneratePermutation(0);
    }

    private static void GeneratePermutation(int index)
    {
        if (index >= length)
        {
            Print();
        }
        else
        {
            HashSet<string> swapped = new HashSet<string>();

            for (int i = index; i < length; i++)
            {
                if (!swapped.Contains(set[i]))
                {
                    Swap(index, i);
                    GeneratePermutation(index + 1);
                    Swap(index, i);
                    swapped.Add(set[i]);
                }                
            }
        }
    }

    private static void Swap(int index, int i)
    {
        string temp = set[index];
        set[index] = set[i];
        set[i] = temp;
    }

    private static void Print()
    {
        Console.WriteLine(string.Join(" ", set));
    }
}