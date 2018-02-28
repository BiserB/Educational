using System;
using System.Linq;

namespace t7
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] first = new int[rows][];
            int[][] second = new int[rows][];
            for (int r = 0; r < rows; r++)
            {
                int[] arr = Console.ReadLine()
                          .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
                first[r] = arr;
            }
            for (int r = 0; r < rows; r++)
            {
                int[] arr = Console.ReadLine()
                          .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
                second[r] = arr;
            }
            int[] elementsCount = new int[rows];
            for (int r = 0; r < rows; r++)
            {
                int firstCount = first[r].Count();
                int secondCount = second[r].Count();
                elementsCount[r] = firstCount + secondCount;
            }
            
            for (int i = 0; i < rows -1; i++)
            {
                if (elementsCount[i] != elementsCount[i + 1])
                {
                    int count = 0;
                    for (int j = 0; j < rows; j++)
                    {
                        count += elementsCount[j];
                    }
                    Console.WriteLine($"The total number of cells is: {count}");
                    break;
                }
                else
                {
                    for (int j = 0; j < rows; j++)
                    {
                        string a = String.Join(", ", first[j]);
                        int[] reversed = second[j].Reverse().ToArray();
                        string b = String.Join(", ", reversed);
                        
                        Console.Write("[" + a + ", " + b + "]");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
