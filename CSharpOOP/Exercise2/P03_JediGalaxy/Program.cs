using System;

namespace JediGalaxy_II
{
    public class Program
    {
        private static long collected = 0;
        private static int[,] matrix = new int[,] { };
        private static int rows = 0;
        private static int cols = 0;

        static void Main()
        {
            CreateMatrix();

            ColectValues();
            
            Console.WriteLine(collected);
        }

        private static void ColectValues()
        {
            string command = "";
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                string[] data = command.Split();
                int ivoRow = int.Parse(data[0]);
                int ivoCol = int.Parse(data[1]);
                string[] evilData = Console.ReadLine().Split();
                int evilRow = int.Parse(evilData[0]);
                int evilCol = int.Parse(evilData[1]);

                //--Evil power destroys all stars from lowest right to the upper left
                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (Check(evilRow, evilCol))
                    {
                        matrix[evilRow, evilCol] = 0;
                    }
                    evilRow--;
                    evilCol--;
                }

                //-- Ivo adds the values only of the stars that are not destroyed
                while (ivoRow >= 0 && ivoCol < cols)
                {
                    if (Check(ivoRow, ivoCol))
                    {
                        collected += matrix[ivoRow, ivoCol];
                    }
                    ivoRow--;
                    ivoCol++;
                }
            }
        }        

        public static void CreateMatrix()
        {
            string[] input = Console.ReadLine().Split();
            rows = int.Parse(input[0]);
            cols = int.Parse(input[1]);            

            matrix = new int[rows, cols];
            int value = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = value++;
                }
            }
        }

        public static bool Check(int r, int c)
        {            
            if (r >= 0 && r < rows && c >= 0 && c < cols)
            {
                return true;
            }
            return false;
        }

        // -- Method for tests
        public static void Print(int[,] matrix)
        {
            Console.WriteLine();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
