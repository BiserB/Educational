using System;
using System.Diagnostics;
using System.Linq;

namespace t4
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] data = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
                matrix[i] = data;
            }
            int r = 0; 
            int c = 0;
            int maxSum = int.MinValue;
            int sum = 0;
            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    sum = matrix[i][j] + matrix[i][j + 1] + matrix[i][j + 2] +
                          matrix[i + 1][j] + matrix[i + 1][j + 1] + matrix[i + 1][j + 2] +
                          matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i + 2][j + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        r = i;
                        c = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = r; i < r + 3; i++)
            {
                for (int j = c; j < c + 3; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
            //for (int i = 0; i < rows; i++)
            //{
            //    Console.WriteLine(String.Join(' ', matrix[i]));
            //}
        }   
    }
}
