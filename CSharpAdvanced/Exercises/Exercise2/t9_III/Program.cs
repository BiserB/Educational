using System;
using System.Collections.Generic;
using System.Linq;

namespace t9_III
{
    class Program
    {
        static void Main()
        {
            int[] matrixSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            var mainList = new List<List<int>>();
            for (int r = 0; r < rows; r++)
            {
                var rowList = new List<int>();
                for (int c = 0; c < cols; c++)
                {
                    rowList.Add(r * cols + c + 1);
                }

                mainList.Add(rowList);
            }

            string command;
            while ((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] commandArgs = command.Split().Select(int.Parse).ToArray();
                int shotRow = commandArgs[0];
                int shotCol = commandArgs[1];
                int radius = commandArgs[2];

                for (int r = 0; r < mainList.Count; r++)
                {
                    for (int c = 0; c < mainList[r].Count; c++)
                    {
                        if ((r == shotRow && Math.Abs(c - shotCol) <= radius) ||
                            (c == shotCol && Math.Abs(r - shotRow) <= radius))
                        {
                            mainList[r][c] = 0;
                        }
                    }
                }

                for (int r = 0; r < mainList.Count; r++)
                {
                    mainList[r].RemoveAll(x => x == 0);
                    if (mainList[r].Count == 0)
                    {
                        mainList.RemoveAt(r);
                        r--;
                    }
                }
            }

            for (int r = 0; r < mainList.Count; r++)
            {
                Console.WriteLine(string.Join(" ", mainList[r]));
            }
        }
    }
}
