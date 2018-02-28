using System;

namespace t9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int[][] matrix = new int[rows][];
            int n = 1;
            for (int i = 0; i < rows; i++)
            {
                int[] arr = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    arr[j] = n;                                   
                    n++;
                }
                matrix[i] = arr;
            }
            string entry = Console.ReadLine();
            while (entry != "Nuke it from orbit")
            {
                string[] command = entry.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(command[0]);
                int col = int.Parse(command[1]);
                int radius = int.Parse(command[2]);

                for (int r = 0; r < matrix.Length; r++)
                {
                    int[] temp = new int[] { matrix[r].Length };
                    
                    for (int i = 0; i < matrix[r].Length; i++)
                    {
                        if (i != col )
                        {
                            temp[i] = matrix[r][i];
                        }
                        
                    }                        
                        
                }




                entry = Console.ReadLine();
            }

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    Console.Write(matrix[r][ c] + " ");
                }
                Console.WriteLine();
            }



           
        }
    }
}
