using System;

namespace L2
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int max = int.MinValue;
            int startRow = 0;
            int startCol = 0;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] data = Console.ReadLine()
                                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    int num = int.Parse(data[col]);
                    matrix[row, col] = num;                    
                }
            }
            for (int i = 0; i < rows -1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    int matrixSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (matrixSum > max)
                    {
                        max = matrixSum;
                        startRow = i;
                        startCol = j;
                    }
                }
            }
            Console.WriteLine($"{matrix[startRow, startCol]} {matrix[startRow, startCol+1]}");
            Console.WriteLine($"{matrix[startRow+1, startCol]} {matrix[startRow+1, startCol+1]}");
            Console.WriteLine(max);
        }
    }
}
