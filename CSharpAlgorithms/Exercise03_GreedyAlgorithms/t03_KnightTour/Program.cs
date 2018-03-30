using System;

public class Program
{
    private static int[,] matrix;
    private static int size;
    private static int counter;

    static void Main()
    {
        size = int.Parse(Console.ReadLine());

        matrix = new int[size, size];

        InitMatrix();

        TraverseMatrix(0,0);

        PrintMatrix();
    }

    private static void TraverseMatrix(int row, int col)
    {
        if (IsOutside(row, col))
        {
            return;
        }

        if (matrix[row, col] != 0)
        {
            return;
        }
        counter++;
        matrix[row, col] = counter;

        TraverseMatrix(row - 1, col + 2);       // Right Up
        TraverseMatrix(row + 1, col + 2);       // Right Down
        TraverseMatrix(row + 2, col + 1);       // Down Right
        TraverseMatrix(row + 2, col - 1);       // Down Left
        TraverseMatrix(row + 1, col - 2);       // Left Down
        TraverseMatrix(row - 1, col - 2);       // Left Up
        TraverseMatrix(row - 2, col - 1);       // Up Left
        TraverseMatrix(row - 2, col + 1);       // Up Left        
    }

    private static bool IsOutside(int row, int col)
    {
        if (row >= 0 && row < size && col >= 0 && col < size)
        {
            return false;
        }
        
        return true;
    }

    private static void InitMatrix()
    {
        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                matrix[r, c] = 0;
            }
        }
    }

    private static void PrintMatrix()
    {
        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                string cell = matrix[r, c].ToString();
                Console.Write(cell.PadLeft(4, ' '));                
            }
            Console.WriteLine();
        }
    }
}
