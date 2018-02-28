using System;
using System.Linq;

namespace t11_III
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int columns = int.Parse(input[1]);
            byte[,] matrix = new byte[rows,columns];

            string command = Console.ReadLine();
            while ((command = Console.ReadLine()) != "stop")
            {
                int[] data = command.Split(' ').Select(int.Parse).ToArray();
                int entrance = data[0];
                int row = data[1];
                int col = data[2];
                
                int steps = Math.Abs(entrance - row) + 1;   // initial steps in first column                                

                if (IsParked(matrix, row, col))
                {
                    steps += col;                           // add steps in the row to initial
                    Console.WriteLine(steps);
                }
                else
                {                                           //     |_|_|_|_|_|_|_|_|_|_|
                    int lowerCounter = col - 1;             // the cells before the desired cell
                    int upperCounter = columns - col - 1;   // the cells after the desired cell

                    while (true)
                    {
                        if (lowerCounter == 0 && upperCounter == 0) // if no more free cells
                        {
                            Console.WriteLine($"Row {row} full");
                            break;
                        }
                        if (lowerCounter > 0)
                        {
                            col = lowerCounter;
                            if (IsParked(matrix, row, col))
                            {
                                steps += col;
                                Console.WriteLine(steps);
                                break;
                            }
                            lowerCounter--;
                        }
                        if (upperCounter > 0)
                        {
                            col = columns - upperCounter;
                            if (IsParked(matrix, row, col))
                            {
                                steps += col;
                                Console.WriteLine(steps);
                                break;
                            }
                            upperCounter--;
                        }
                    }
                }
            }
        }
        static bool IsParked(byte[,] matrix, int row, int col)      // check the desired cell
        {           
            if (matrix[row, col] == 0)
            {
                matrix[row, col] = 1;
                return true;
            }
            return false;
        }
    }
}
