using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<int[]> result = new List<int[]>();


    static void Main()
    {
        //int[] universe = Console.ReadLine().Split().Select(int.Parse).ToArray();

        //int setsNumber = int.Parse(Console.ReadLine());

        //List<int[]> sets = new List<int[]>();

        //for (int i = 0; i < setsNumber; i++)
        //{
        //    int[] set = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //    sets.Add(set);
        //}

        List<int> universe = new List<int> { 1, 3, 5, 7, 9, 11, 20, 30, 40 };

        List<int[]> sets = new List<int[]>
        {
            new int[]{20},
            new int[]{1, 5, 20, 30},
            new int[]{3, 7, 20, 30, 40},
            new int[]{ 9, 30 },
            new int[]{ 11, 20, 30, 40 },
            new int[]{ 3, 7, 40 }
        };

        sets = sets.OrderByDescending(s => s.Length).ToList();

        int[] matches = new int[sets.Count];

        while (universe.Count > 0)
        {
            FindMatches(universe, sets, matches);

            int indexOfMax = 0;

            for (int i = 0; i < matches.Length - 1; i++)
            {
                if (matches[i] > matches[i + 1])
                {
                    indexOfMax = i;
                }
            }

            int[] setToRemove = sets[indexOfMax];

            result.Add(setToRemove);

            sets.Remove(setToRemove);

            for (int i = 0; i < setToRemove.Length; i++)
            {
                int element = setToRemove[i];

                universe.Remove(element);
            }
        }

        Console.WriteLine($"Sets to take ({result.Count}):");

        foreach (var item in result)
        {
            string elements = string.Join(", ", item);
            Console.WriteLine($"{ elements }");
        }

    }

    private static void FindMatches(List<int> universe, List<int[]> sets, int[] matches)
    {

        matches = new int[sets.Count];

        for (int i = 0; i < sets.Count; i++)
        {
            int currentMatches = 0;
            foreach (int num in sets[i])
            {
                if (universe.Contains(num))
                {
                    currentMatches++;
                }
            }
            matches[i] = currentMatches;
        }
    }
}