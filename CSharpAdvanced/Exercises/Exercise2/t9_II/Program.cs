using System;
using System.Collections.Generic;

namespace t9_II
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            List<List<int>> matrix = new List<List<int>>();
            int n = 1;
            for (int r = 0; r < rows; r++)
            {
                matrix.Add(new List<int>());
                for (int c = 0; c < cols; c++)
                {
                    matrix[r].Add(n);
                    n++;
                }
               
            }
            string entry = Console.ReadLine();
            while (entry != "Nuke it from orbit")
            {
                string[] command = entry.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(command[0]);
                int col = int.Parse(command[1]);
                int radius = int.Parse(command[2]);

                for (int r = 0; r < matrix.Count; r++)          //-- delete vertical elements in matrix
                {
                    if (r >= row - radius && r <= row + radius)
                    {
                        if (col >= 0 && col < matrix[r].Count)
                        {
                            matrix[r][col] = 0;
                        } 
                    }
                    for (int c = 0; c < matrix[r].Count; c++)          //-- delete horizontal elements in matrix
                    {
                        if (c >= col - radius && c <= col + radius && r == row)
                        {                            
                                matrix[r][c] = 0; 
                        }
                    }
                }
                for (int r = 0; r < matrix.Count; r++)
                {
                    matrix[r].RemoveAll(x => x == 0);

                    if (matrix[r].Count == 0)
                    {
                        matrix.RemoveAt(r);
                        r--;
                    }
                }


                entry = Console.ReadLine();
            }



            for (int r = 0; r < matrix.Count; r++)
            {
                for (int c = 0; c < matrix[r].Count; c++)
                {
                    Console.Write(matrix[r][c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
