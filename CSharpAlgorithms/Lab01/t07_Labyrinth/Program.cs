// You are given a labyrinth. Your goal is to find all paths 
// from the start (cell 0, 0) to the exit, marked with 'e'. 
// Empty cells are marked with a dash '-'.
// Walls are marked with a star '*';
// Visited cells are marked with a period '.';

using System;
using System.Collections.Generic;

public class Program
{
    private static char[][] labyrinth;
    private static List<char> directions;
    private static int rows;
    private static int cols;

    static void Main()
    {
        rows = int.Parse(Console.ReadLine());
        cols = int.Parse(Console.ReadLine());

        labyrinth = new char[rows][];
        directions = new List<char>();

        for (int r = 0; r < rows; r++)
        {
            labyrinth[r] = Console.ReadLine().ToCharArray();
        }

        FindPath(0, 0, 'S');
    }

    private static void FindPath(int row, int col, char direction)
    {
        if (CellIsOutside(row, col))
        {
            return;
        }
        directions.Add(direction);
        if (CellIsExit(row, col))
        {
            PrintPath();
        }
        else if (CellIsFree(row, col))
        {
            MarkCell(row, col);
            FindPath(row, col + 1, 'R');
            FindPath(row + 1, col, 'D');
            FindPath(row , col -1, 'L');
            FindPath(row - 1, col, 'U');
            UnmarkCell(row, col);            
        }
        directions.RemoveAt(directions.Count - 1);
    }

    private static void PrintPath()
    {
        for (int i = 1; i < directions.Count; i++)
        {
            Console.Write(directions[i]);
        }
        Console.WriteLine();
    }

    private static void UnmarkCell(int row, int col)
    {
        labyrinth[row][col] = '-';
    }

    private static void MarkCell(int row, int col)
    {
        labyrinth[row][col] = '.';

    }

    private static bool CellIsFree(int row, int col)
    {
        if (labyrinth[row][col] == '*')
        {
            return false;
        }
        if (labyrinth[row][col] == '.')
        {
            return false;
        }
        return true;
    }

    private static bool CellIsOutside(int row, int col)
    {
        if ((row >= 0 && row < rows) && (col >= 0 && col < cols))
        {
            return false;
        }        
        return true;
    }

    private static bool CellIsExit(int row, int col)
    {
        if (labyrinth[row][col] != 'e')
        {
            return false;
        }
        return true;
    }
}
