using System;
using System.Collections;

namespace t6
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            char[] snake = Console.ReadLine().ToCharArray();
            string[] shot = Console.ReadLine().Split();
            int shotRow = int.Parse(shot[0]);
            int shotColumn = int.Parse(shot[1]);
            int radius = int.Parse(shot[2]);

            char[,] matrix = new char[rows, cols];
            //----------------------------------------------------------populate matrix
            int index = 0;
            bool rightToLeft = true;            
            for (int r = rows - 1; r >= 0 ; r--)
            {
                if (rightToLeft)
                {
                    for (int c = cols - 1; c >= 0; c--)
                    {
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                        matrix[r,c] = snake[index];
                        index++;
                    }
                }
                else
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                        matrix[r, c] = snake[index];
                        index++;
                    }
                }                
                rightToLeft = !rightToLeft;
            }
            //----------------------------------------------------------shot to matrix
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    double distance = Math.Sqrt(Math.Pow(r - shotRow, 2) + Math.Pow(c - shotColumn, 2));
                    if (distance <= radius)
                    {
                        matrix[r, c] = ' ';
                    }
                }
            }
            //-------------------------------------------------------check for whitespaces
            for (int c = 0; c < cols; c++)
            {
                for (int i = 0; i < rows ; i++)
                {
                    for (int r = rows - 1; r > 0; r--)
                    {
                        if (matrix[r, c] == ' ')
                        {
                            matrix[r, c] = matrix[r - 1, c];
                            matrix[r - 1, c] = ' ';
                        }
                    }
                }  
            }
            //-------------------------------------------------------print result
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
