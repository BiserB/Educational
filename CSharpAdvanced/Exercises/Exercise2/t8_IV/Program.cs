using System;

namespace t8_IV
{
    class Program
    {
        public static char[,] matrix = new char[,] { };
        public static int rows = 0;
        public static int cols = 0;
        public static int playerRow = 0;
        public static int playerCol = 0;
        public static Func<int, int, bool> check = (r, c) =>
        {
            if (r >= 0 && r < rows && c >= 0 && c < cols)
            {
                return true;
            }
            return false;
        };

        static void Main()
        {
            string[] size = Console.ReadLine().Split(' ');
            rows = int.Parse(size[0]);
            cols = int.Parse(size[1]);
            matrix = new char[rows, cols];            
            for (int r = 0; r < rows; r++)
            {
                char[] arr = Console.ReadLine().ToCharArray();
                for (int c = 0; c < arr.Length; c++)
                {
                    matrix[r, c] = arr[c];
                    if (arr[c] == 'P')
                    {
                        playerRow = r;
                        playerCol = c;
                    }
                }
            }
            string directions = Console.ReadLine();
            
            foreach (char ch in directions)
            {
                switch (ch)
                {
                    case 'U':
                        MoveUp();                        
                        break;
                    case 'D':
                        MoveDown();
                        break;
                    case 'L':
                       MoveLeft();
                        break;
                    case 'R':
                        MoveRight();
                        break;
                }
            }

        }

        private static void MoveRight()
        {
            matrix[playerRow, playerCol] = '.';
            playerCol++;
            Multiplication();
            if (playerCol >= cols)
            {
                playerCol--;
                PrintOut(true);
            }
            else if (matrix[playerRow, playerCol] == 'B')
            {
                PrintOut(false);
            }
            else
            {
                matrix[playerRow, playerCol] = 'P';
            }
        }

        private static void MoveLeft()
        {
            matrix[playerRow, playerCol] = '.';
            playerCol--;
            Multiplication();
            if (playerCol < 0)
            {
                playerCol++;
                PrintOut(true);
            }
            else if (matrix[playerRow, playerCol] == 'B')
            {
                PrintOut(false);
            }
            else
            {
                matrix[playerRow, playerCol] = 'P';
            }
        }

        private static void MoveDown()
        {
            matrix[playerRow, playerCol] = '.';
            playerRow++;
            Multiplication();
            if (playerRow >= rows)
            {
                playerRow--;
                PrintOut(true);
            }
            else if (matrix[playerRow, playerCol] == 'B')
            {
                PrintOut(false);
            }
            else
            {
                matrix[playerRow, playerCol] = 'P';
            }
        }

        private static void MoveUp()
        {
            matrix[playerRow, playerCol] = '.';
            playerRow--;
            Multiplication();
            if (playerRow < 0)
            {
                playerRow++;                
                PrintOut(true);                
            }
            else if (matrix[playerRow,playerCol] == 'B')
            {
                PrintOut(false);
            }
            else
            {
                matrix[playerRow, playerCol] = 'P';
            }
        }

        private static void Multiplication()
        {
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
                    if (matrix[r, c] == 'B')
                    {
                        copy[r, c] = 'B';
                        if (check(r - 1, c)) { copy[r - 1, c] = 'B'; }
                        if (check(r + 1, c)) { copy[r + 1, c] = 'B'; }
                        if (check(r, c - 1)) { copy[r, c - 1] = 'B'; }
                        if (check(r, c + 1)) { copy[r, c + 1] = 'B'; }
                    }
                }
            }            
            matrix = copy;            
        }

        private static void PrintOut(bool win)
        {            
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
            if (win)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            Environment.Exit(0);
        }

        private static void PrintMatrix()
        {
            Console.WriteLine();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
            
        }

        private static void PrintCopy(char[,] copy)
        {
            Console.WriteLine("-- copy --");
            for (int r = 0; r < copy.GetLength(0); r++)
            {
                for (int c = 0; c < copy.GetLength(1); c++)
                {
                    Console.Write(copy[r, c]);
                }
                Console.WriteLine();
            }

        }

    }
}
