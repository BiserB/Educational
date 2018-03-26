using System;
using System.Collections.Generic;

public class Program
{
    private static List<string> forms =  new List<string>();

    private static bool[,] matrix;
    private static int length;
    private static int counter;
    private static int rows;
    private static int cols;
    private static List<char> directions = new List<char>();

    static void Main()
    {
        length = int.Parse(Console.ReadLine());

        counter = length;

        rows = cols = (2 * length) - 1;

        matrix = new bool[rows, cols];

        int startRow = length - 1;
        int startCol = length - 1;        

        GenerateSnake(startRow, startCol, 'S');

    }

    private static void GenerateSnake(int row, int col, char direction)
    {
        if (IsOtside(row, col) ) 
        {
            return;
        }

        directions.Add(direction);

        counter--;

        if (counter == 0)
        {
            string form = "";
            foreach (char ch in directions)
            {
                form += ch;
            }
            forms.Add(form);
            directions.Clear();
            counter = length;
        }
        
        if (matrix[row, col] == false)
        {
            matrix[row, col] = true;

            GenerateSnake(row, col + 1, 'R');
            GenerateSnake(row - 1, col, 'D');
            GenerateSnake(row, col - 1, 'L');
            GenerateSnake(row - 1, col, 'U');

            matrix[row, col] = false;
        }
        
        // directions.RemoveAt(directions.Count - 1);
    }

    private static bool IsOtside(int row, int col)
    {
        if (row < 0 || row >= rows || col < 0 || col >= cols)
        {
            return true;
        }
        return false;
    }
}
