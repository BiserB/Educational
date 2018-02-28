using System;
using System.Linq;

namespace t11
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int columns = int.Parse(input[1]);
            byte[,] matrix = new byte[rows, columns];       // matrix filled with 0
                                                            // 0 for empty, 1 for occupied
            string command = "";
            while ((command = Console.ReadLine()) != "stop")
            {
                int[] data = command.Split(' ').Select(int.Parse).ToArray();
                int entrance = data[0];
                int row = data[1];
                int col = data[2];
                int steps = Math.Abs(entrance - row) + 1;   // initial steps in first (0) column

                if (matrix[row, col] == 0)
                {
                    matrix[row, col] = 1;
                    steps += col;                           // add steps in the row to the initial steps
                    Console.WriteLine(steps);
                }                                               
                else                                        // lower -- v v v v   v v v v v --upper
                {                                           // row-->|0|_|_|_|_|X|_|_|_|_|_|   
                    int cnt = 1;
                    while (true)
                    {
                        int lowerCell = col - cnt;              // the cells before desired cell 
                        int upperCell = col + cnt;              // the cells after desired cell

                        if (lowerCell < 1 && upperCell > columns - 1)  // if cells are out of bounds
                        {
                            Console.WriteLine($"Row {row} full");
                            break;
                        }
                        if (lowerCell > 0 && matrix[row,lowerCell] == 0)       // if cell is inside of the row
                        {                                                       // and free
                            matrix[row,lowerCell] = 1;
                            steps += lowerCell;
                            Console.WriteLine(steps);
                            break;
                        }
                        if (upperCell < columns && matrix[row,upperCell] == 0)  // if cell is inside of the row
                        {                                                        // and is free
                            matrix[row,upperCell] = 1;
                            steps += upperCell;
                            Console.WriteLine(steps);
                            break;
                        }
                        cnt++;
                    }
                }
            }
        }        
    }
}