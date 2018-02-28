using System;
using System.Collections.Generic;
using System.Linq;


namespace t12
{
    class Program
    {
        static void Main()
        {
            int angle = int.Parse(Console.ReadLine().Split(new char[] { '(', ')' },StringSplitOptions.RemoveEmptyEntries).Last());
            
            List<string> list = new List<string>();
            string input;
            int cols = 0;
            while ((input = Console.ReadLine()) != "END" )
            {
                if (input.Length > cols)
                {
                    cols = input.Length;
                }
                list.Add(input);
            }
            int rows = list.Count;
            char[,] matrix = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                string current = list[r];
                for (int c = 0; c < cols; c++)
                {
                    if (c < current.Length)
                    {
                        matrix[r, c] = current[c];
                    }
                    else
                    {
                        matrix[r, c] = ' ';
                    }
                }
            }
            int rotate = (angle / 90) % 4 ;            

            if (rotate == 1)
            {
                for (int c = 0; c < cols; c++)
                {
                    for (int r = rows - 1; r >= 0; r--)
                    {
                        Console.Write(matrix[r,c]);
                    }
                    Console.WriteLine();
                }
            }
            else if (rotate == 2)
            {
                for (int r = rows - 1; r >= 0; r--) 
                {
                    for (int c = cols - 1; c >= 0; c--)
                    {
                        Console.Write(matrix[r, c]);
                    }
                    Console.WriteLine();
                }
            }
            if (rotate == 3)
            {
                for (int c = cols -1; c >= 0; c--)
                {
                    for (int r = 0; r < rows; r++)
                    {
                        Console.Write(matrix[r, c]);
                    }
                    Console.WriteLine();
                }
            }
            else if (rotate == 0)
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        Console.Write(matrix[r, c]);
                    }
                    Console.WriteLine();
                }
            }
            

        }
    }
}
