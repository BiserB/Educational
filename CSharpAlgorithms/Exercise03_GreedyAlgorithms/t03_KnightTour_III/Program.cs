
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int[,] matrix;
    private static int size;
    private static int counter = 1;
    
    static int[] r = { 1, -1,  1, -1,  2,  2, -2, -2 };
    static int[] c = { 2,  2, -2, -2,  1, -1,  1, -1 };

    static void Main()
    {
        size = int.Parse(Console.ReadLine());

        matrix = new int[size, size];

        InitMatrix();

        TraverseMatrix(0, 0);

        PrintMatrix();
    }

    private static void TraverseMatrix(int row, int col)
    {
        matrix[row, col] = counter;

        Cell next = NextCell(row, col);

        while (next != null)
        {
            counter++;

            row = next.Row;

            col = next.Col;

            matrix[row, col] = counter;

            next = NextCell(row, col);
        }
    }

    private static Cell NextCell(int row, int col)
    {
        List<Cell> nextCells = new List<Cell>();

        for (int i = 0; i < 8; i++)
        {
            int currentRow = row + r[i];
            int currentCol = col + c[i];

            if (IsEmpty(currentRow, currentCol))
            {
                int moves = MovesAvailable(currentRow, currentCol);
                Cell cell = new Cell(currentRow, currentCol, moves);
                nextCells.Add(cell);
            }
        }

        if (nextCells.Count > 0)
        {
            return nextCells.OrderBy(c => c.Moves).First();
        }
        return null;
    }

    private static int MovesAvailable(int row, int col)
    {
        int moves = 0;

        for (int i = 0; i < 8; i++)
        {
            if (IsEmpty(row + r[i], col + c[i]))
            {
                moves++;
            }
        }  
        
        return moves;
    }

    private static bool IsInside(int row, int col)
    {
        if (row < 0 || row >= size)
        {
            return false;
        }
        if (col < 0 || col >= size)
        {
            return false;
        }

        return true;
    }

    private static bool IsEmpty(int row, int col)
    {
        if (IsInside(row, col) && matrix[row, col] == 0)
        {
            return true;
        }
        return false;
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

public class Cell
{
    public Cell(int row, int col, int moves)
    {
        Row = row;
        Col = col;
        Moves = moves;
    }

    public int Row { get; }
    public int Col { get; }
    public int Moves { get; }
}
