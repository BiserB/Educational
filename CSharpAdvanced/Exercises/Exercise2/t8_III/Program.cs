using System;
using System.Linq;

namespace t8_III
{
    class Program
    {
        static void Main()
        {
            string firstInputLine = Console.ReadLine();

            int[] lairDimentions = firstInputLine.Split(' ').Select(int.Parse).ToArray();

            char[,] lair = new char[lairDimentions[0], lairDimentions[1]];

            char[,] infestedLair = new char[lairDimentions[0], lairDimentions[1]];

            int playerPositionRow = 0;

            int playerPositionCol = 0;

            
            for (int i = 0; i < lairDimentions[0]; i++)
            {
                string inputLine = Console.ReadLine();

                if (inputLine.Contains('P'))
                {
                    playerPositionRow = i;
                    playerPositionCol = inputLine.IndexOf('P');
                }
                for (int j = 0; j < inputLine.Length; j++)
                {
                    lair[i, j] = inputLine[j];
                }
            }
            int newPlayerPositionRow = 0;
            int newPlayerPositionCol = 0;
            
            string commands = Console.ReadLine();
            
            for (int j = 0; j < commands.Length; j++)
            {
                lair[playerPositionRow, playerPositionCol] = '.';

                switch (commands[j])
                {
                    case 'U':
                        newPlayerPositionRow = playerPositionRow - 1;
                        newPlayerPositionCol = playerPositionCol;
                        break;
                    case 'D':
                        newPlayerPositionRow = playerPositionRow + 1;
                        newPlayerPositionCol = playerPositionCol;
                        break;
                    case 'L':
                        newPlayerPositionRow = playerPositionRow;
                        newPlayerPositionCol = playerPositionCol - 1;
                        break;
                    case 'R':
                        newPlayerPositionRow = playerPositionRow;
                        newPlayerPositionCol = playerPositionCol + 1;
                        break;
                }

                if (newPlayerPositionRow < 0 ||
                    newPlayerPositionRow >= lair.GetLength(0) ||
                    newPlayerPositionCol < 0 ||
                    newPlayerPositionCol >= lair.GetLength(1))
                {
                    PrintLair(InfestLair(lair));
                    PrintResult("won", playerPositionRow, playerPositionCol);
                    return;
                }
                else if (lair[newPlayerPositionRow, newPlayerPositionCol] == 'B')
                {
                    PrintLair(InfestLair(lair));
                    PrintResult("dead", newPlayerPositionRow, newPlayerPositionCol);
                    return;
                }
                else //if (lair[newPlayerPositionRow, newPlayerPositionCol] == '.')
                {
                    lair = InfestLair(lair);

                    if (lair[newPlayerPositionRow, newPlayerPositionCol] == 'B')
                    {
                        PrintLair(lair);
                        PrintResult("dead", newPlayerPositionRow, newPlayerPositionCol);
                        return;
                    }

                    playerPositionRow = newPlayerPositionRow;
                    playerPositionCol = newPlayerPositionCol;
                    //lair[playerPositionRow, playerPositionCol] = 'P';
                }

                
            }
        }

        static void PrintLair(char[,] lair)
        {
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    Console.Write(lair[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void PrintResult(string gameResult, int playerPositionRow, int playerPositionCol)
        {
            Console.WriteLine("{0}: {1} {2}", gameResult, playerPositionRow, playerPositionCol);
        }

        static char[,] InfestLair(char[,] lair)
        {
            char[,] infestedLair = new char[lair.GetLength(0), lair.GetLength(1)];
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (infestedLair[row, col] != 'B')
                    {
                        infestedLair[row, col] = lair[row, col];
                    }

                    if (lair[row, col] == 'B')
                    {
                        if (row - 1 >= 0)
                        {
                            infestedLair[row - 1, col] = 'B';
                        }
                        if (row + 1 < infestedLair.GetLength(0))
                        {
                            infestedLair[row + 1, col] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            infestedLair[row, col - 1] = 'B';
                        }
                        if (col + 1 < infestedLair.GetLength(1))
                        {
                            infestedLair[row, col + 1] = 'B';
                        }
                    }
                }
            }

            return infestedLair;
        }
    }
}
