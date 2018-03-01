using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static int rows = 0;
        static int cols = 0;
        static int[] samPosition = new int[2];         

        static void Main()
        {
            BuildRoom();

            var moves = Console.ReadLine().ToCharArray();

            FindSamPosition();
            
            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies();                

                int[] getEnemy = new int[2];
                for (int j = 0; j < room[samPosition[0]].Length; j++)
                {
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }
                }
                if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }
                    Environment.Exit(0);
                }
                else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }
                    Environment.Exit(0);
                }


                room[samPosition[0]][samPosition[1]] = '.';
                switch (moves[i])
                {
                    case 'U':
                        samPosition[0]--;
                        break;
                    case 'D':
                        samPosition[0]++;
                        break;
                    case 'L':
                        samPosition[1]--;
                        break;
                    case 'R':
                        samPosition[1]++;
                        break;
                    default:
                        break;
                }
                room[samPosition[0]][samPosition[1]] = 'S';

                for (int j = 0; j < room[samPosition[0]].Length; j++)
                {
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }
                }
                if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
                {
                    room[getEnemy[0]][getEnemy[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }
                    Environment.Exit(0);
                }
            }
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (CheckRight(row, col))
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (CheckLeft(row, col))
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        public static void BuildRoom()
        {
            rows = int.Parse(Console.ReadLine());
            room = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                cols = input.Length;
                room[row] = new char[cols];
                for (int col = 0; col < cols; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }

        private static void FindSamPosition()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        private static bool CheckRight(int row, int col)
        {
            if (row >= 0 && row < rows && col + 1 >= 0 && col + 1 < cols)
            {
                return true;
            }
            return false;
        }

        private static bool CheckLeft(int row, int col)
        {
            if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
