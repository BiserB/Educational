using System;
using System.Collections.Generic;

namespace t5
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int cnt = int.Parse(Console.ReadLine());
            int[,] initial = new int[rows, cols];
            int[,] matrix = new int[rows, cols]; 
            int n = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    initial[i, j] = n;
                    matrix[i, j] = n;
                    n++;
                }
            }
            for (int i = 0; i < cnt; i++)
            {
                string[] command = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string direction = command[1];
                switch (direction)
                {
                    case "up":
                         MoveUp(command, matrix);                        
                        break;
                    case "down":
                         MoveDown(command, matrix);
                        break;
                    case "left":
                         MoveLeft(command, matrix);
                        break;
                    case "right":
                         MoveRight(command, matrix);
                        break;
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int num = initial[row, col];                    
                    if (matrix[row,col] == num)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {                        
                        bool match = false;
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (matrix[i,j] == num)
                                {
                                    match = true;
                                    matrix[i, j] = matrix[row, col];
                                    matrix[row, col] = num;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({i}, {j})");
                                    break;
                                }
                            }
                            if (match)
                            {
                                break;
                            }
                        }                        
                    }
                }
            }
        }
        static void MoveRight(string[] command, int[,] matrix)
        {
            int row = int.Parse(command[0]);
            int places = int.Parse(command[2]);
            places = places % matrix.GetLength(1);
            Queue<int> temp = new Queue<int>();

            for (int col = matrix.GetLength(1) -1; col >= 0 ; col--)
            {
                temp.Enqueue(matrix[row, col]);
            }          
            for (int p = 0; p < places; p++)
            {
                int t = temp.Dequeue();
                temp.Enqueue(t);
            }
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                matrix[row, col] = temp.Dequeue();
            }            
            
        }

        static void MoveLeft(string[] command, int[,] matrix)
        {
            int row = int.Parse(command[0]);
            int places = int.Parse(command[2]);
            places = places % matrix.GetLength(1);
            Queue<int> temp = new Queue<int>();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                temp.Enqueue(matrix[row, col]);
            }
            for (int p = 0; p < places; p++)
            {
                int t = temp.Dequeue();
                temp.Enqueue(t);
            }
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = temp.Dequeue();
            }
        }

        static void MoveDown(string[] command, int[,] matrix)
        {    
            int column = int.Parse(command[0]);
            int places = int.Parse(command[2]);
            places = places % matrix.GetLength(1);
            Queue<int> temp = new Queue<int>();

            for (int row = matrix.GetLength(0) -1; row >= 0; row--)
            {
                temp.Enqueue(matrix[row, column]);
            }
            for (int a = 0; a < places; a++)
            {
                int t = temp.Dequeue();
                temp.Enqueue(t);
            }
            for (int i = matrix.GetLength(0) - 1; i >= 0 ; i--)
            {
                matrix[i, column] = temp.Dequeue();
            }            
        }

        static void MoveUp(string[] command, int[,] matrix)
        {
            int column = int.Parse(command[0]);
            int places = int.Parse(command[2]);
            Queue<int> temp = new Queue<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                temp.Enqueue(matrix[row, column]);
            }
            
                places = places % matrix.GetLength(1);
            
            for (int a = 0; a < places; a++)
            {
                int t = temp.Dequeue();
                temp.Enqueue(t);
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, column] = temp.Dequeue();
            }
            
        }
    }
}

