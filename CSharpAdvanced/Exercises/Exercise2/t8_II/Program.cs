using System;

namespace t8_II
{
    class Program
    {
        static void Main()
        {
            string[] size = Console.ReadLine().Split(' ');
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);
            char[,] matrix = new char[rows, cols];
            //---------------------------------------------------populate matrix
            for (int r = 0; r < rows; r++)
            {
                char[] arr = Console.ReadLine().ToCharArray();
                for (int c = 0; c < arr.Length; c++)
                {
                    matrix[r, c] = arr[c];
                }
            }
            
            string directions = Console.ReadLine();

            Mutate(matrix);
            foreach (char ch in directions)
            {
                switch (ch)
                {
                    //case 'U':
                    //    matrix = MoveUp(matrix);
                    //    break;
                    //case 'D':
                    //    matrix = MoveDown(matrix);
                    //    break;
                    //case 'L':
                    //    matrix = MoveLeft(matrix);
                    //    break;
                    //case 'R':
                    //    matrix = MoveRight(matrix);
                    //    break;
                }
            }

        }
        private static void Mutate(char[,] matrix)
        {
            int rows = matrix.GetLength(0) + 2;
            int cols = matrix.GetLength(1) + 2;
            char[,] copy = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    copy[r, c] = '.';                    
                }
            }
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (matrix[r, c] == 'B')                // -- Bunny found
                    {
                        copy[r, c] = 'B';
                        if (r == 0)                           // -- Border case
                        {
                            if (c == 0)                       //-- Upper left corner
                            {
                                copy[r + 1, c] = 'B';
                                copy[r, c + 1] = 'B';
                            }
                            else if (c == cols - 1)           //-- Upper right corner
                            {
                                copy[r + 1, c] = 'B';
                                copy[r, c - 1] = 'B';
                            }
                            else                               //--upper side of matrix
                            {
                                copy[r, c - 1] = 'B';
                                copy[r, c + 1] = 'B';
                                copy[r + 1, c] = 'B';
                            }
                        }
                        else if (r == rows - 1)               // -- Border case
                        {
                            if (c == 0)                       //--lower left corner
                            {
                                copy[r, c + 1] = 'B';
                                copy[r - 1, c] = 'B';
                            }
                            else if (c == cols - 1)            //--lower right corner
                            {
                                copy[r, c - 1] = 'B';
                                copy[r - 1, c] = 'B';
                            }
                            else                                //--lower side of matrix
                            {
                                copy[r, c - 1] = 'B';
                                copy[r, c + 1] = 'B';
                                copy[r - 1, c] = 'B';
                            }
                        }
                        else if (c == 0)                         //--left side of matrix
                        {
                            copy[r - 1, c] = 'B';
                            copy[r + 1, c] = 'B';
                            copy[r, c + 1] = 'B';
                        }
                        else if (c == cols - 1)                 //--right side of matrix
                        {
                            copy[r - 1, c] = 'B';
                            copy[r + 1, c] = 'B';
                            copy[r, c - 1] = 'B';
                        }
                        else                                   //inside of matrix
                        {
                            copy[r - 1, c] = 'B';
                            copy[r + 1, c] = 'B';
                            copy[r, c - 1] = 'B';
                            copy[r, c + 1] = 'B';
                        }
                    }
                }
            }
           
            
            
        }

        private static void PrintOtput(char[,] matrix, int finalRow, int finalCol, bool death)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
            if (death)
            {
                Console.WriteLine($"dead: {finalRow} {finalCol}");
            }
            else
            {
                Console.WriteLine($"won: {finalRow} {finalCol}");
            }
            //Environment.Exit(0);
        }
    }
}
