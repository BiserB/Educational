using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace t06_Connected_Areas_in_a_Matrix
{
    public class Program
    {
        private static char[,] matrix;
        private static int rows;
        private static int cols;
        private static int areaSize;
        private static List<Area> areas = new List<Area>();


        static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            matrix = new char[rows,cols];

            for (int r = 0; r < rows; r++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = input[c];
                }                
            }

            Cell freeCell = FindFreeCell();

            while (freeCell != null)
            {
                int startRow = freeCell.Row;
                int startCol = freeCell.Col;

                areaSize = 0;
                Area a = new Area();                
                a.InitialRow = startRow;
                a.InitialCol = startCol;
                FindArea(startRow, startCol);
                if (areaSize > 0)
                {
                    a.Size = areaSize;
                    areas.Add(a);
                }

                freeCell = FindFreeCell();
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Total areas found: {areas.Count}");
            int num = 1;
            var ordered = areas.OrderByDescending(a => a.Size)
                                .ThenBy(a => a.InitialRow)
                                .ThenBy(a => a.InitialCol);
            foreach (var area in ordered)
            {
                sb.AppendLine($"Area #{num++} at ({area.InitialRow}, {area.InitialCol}), size: {area.Size}");
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void FindArea(int row, int col)
        {
            if (!IncideCell(row, col))
            {
                return;
            }            
            if ( matrix[row,col] == '-')
            {
                matrix[row,col] = 'v';
                areaSize++;
                FindArea(row, col + 1);
                FindArea(row + 1, col);
                FindArea(row, col - 1);
                FindArea(row -1, col );
            }
        }

        private static Cell FindFreeCell()
        {            
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (matrix[r,c] == '-')
                    {
                        Cell result = new Cell();
                        result.Row = r;
                        result.Col = c;
                        return result;
                    }
                }
            }
            return null;
        }


        private static bool IncideCell(int row, int col)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }
    }

    public class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }

    public class Area
    {
        public int Size { get; set; }
        public int InitialRow { get; set; }
        public int InitialCol { get; set; }
    }
}


