using System;
using System.Collections.Generic;


public class Program
{
    
    static void Main()
    {
        Board chessBoard = new Board();

        chessBoard.PlaceQueen(0);

        //Console.WriteLine($"Solutions = {chessBoard.solutions}");
    }
    
}

public class Board
{
    private readonly int SIZE = 8;
    public int solutions = 0;

    public Board()
    {
        Positions = new bool[SIZE, SIZE];
        
        AttackedCols = new HashSet<int>();
        AttackedLeftDiagonals = new HashSet<int>();
        AttackedRightDiagonals = new HashSet<int>();
    }

    public bool[,] Positions { get; set; }
    
    public HashSet<int> AttackedCols { get; set; }
    public HashSet<int> AttackedLeftDiagonals { get; set; }
    public HashSet<int> AttackedRightDiagonals { get; set; }

    public void PlaceQueen(int row)
    {
        if (row == SIZE)
        {
            PrintBoard();
            solutions++;
        }
        for (int col = 0; col < SIZE; col++)
        {
            if (PositionIsFree(row, col))
            {
                OcupyPosition(row, col);
                PlaceQueen(row + 1);
                FreePosition(row, col);
            }
        }
    }

    private bool PositionIsFree(int row, int col)
    {
        if (AttackedCols.Contains(col))
        {
            return false;
        }
        if (AttackedLeftDiagonals.Contains(col - row) || AttackedRightDiagonals.Contains(col + row))
        {
            return false;
        }
        return true;
    }

    private void FreePosition(int row, int col)
    {
        Positions[row, col] = false;
       
        AttackedCols.Remove(col);
        AttackedLeftDiagonals.Remove(col - row);
        AttackedRightDiagonals.Remove(col + row);
    }

    private void OcupyPosition(int row, int col)
    {
        
        AttackedCols.Add(col);
        AttackedLeftDiagonals.Add(col - row);
        AttackedRightDiagonals.Add(col + row);
        Positions[row, col] = true;
    }

    private void PrintBoard()
    {
        for (int r = 0; r < SIZE; r++)
        {
            for (int c = 0; c < SIZE; c++)
            {
                if (Positions[r, c])
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write("- ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}