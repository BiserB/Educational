using System;
using System.Collections.Generic;

public class Program
{
    static char[] currentSnake;
    static HashSet<string> visited = new HashSet<string>();
    static HashSet<string> snakes = new HashSet<string>();
    static HashSet<string> allSnakes = new HashSet<string>();
    static int n;

    static void GenerateSnakes(int index, int row, int col, char direction)
    {
        if (index >= currentSnake.Length)
        {
            RegisterSnake();
        }
        else
        {
            string cell = $"{row} {col}";

            if (!visited.Contains(cell))
            {
                visited.Add(cell);

                currentSnake[index] = direction;

                GenerateSnakes(index + 1, row, col + 1, 'R');
                
                GenerateSnakes(index + 1, row + 1, col, 'D');
                
                GenerateSnakes(index + 1, row, col - 1, 'L');
                
                GenerateSnakes(index + 1, row - 1, col, 'U');
                visited.Remove(cell);

            }
        }
    }

    private static void RegisterSnake()
    {
        string snake = new string(currentSnake);

        if (!allSnakes.Contains(snake))
        {
            snakes.Add(snake);            

            string reversed = Reverse(snake);                      

            string flipped = Flip(snake);            

            string doubleFlipped = Flip(reversed);
            

            for (int i = 0; i < 4; i++)
            {
                allSnakes.Add(snake);
                snake = Rotate(snake);

                allSnakes.Add(reversed);
                reversed = Rotate(reversed);
                
                allSnakes.Add(flipped);
                flipped = Rotate(flipped);

                allSnakes.Add(doubleFlipped);
                doubleFlipped = Rotate(doubleFlipped);
            }
        }

    }

    private static string Reverse(string snake)
    {
        char[] clone = new char[n];
        clone[0] = 'S';

        for (int i = 1; i < n; i++)
        {
            clone[i] = snake[n - i];
        }

        return new string(clone);
    }

    private static string Rotate(string snake)
    {
        char[] clone = new char[n];

        for (int i = 0; i < clone.Length; i++)
        {
            switch (snake[i])
            {
                case 'U':
                    clone[i] = 'L';
                    break;
                case 'L':
                    clone[i] = 'D';
                    break;
                case 'D':
                    clone[i] = 'R';
                    break;
                case 'R':
                    clone[i] = 'U';
                    break;
                case 'S':
                    clone[i] = 'S';
                    break;
            }
        }

        return new string(clone);
    }

    private static string Flip(string snake)
    {        
        char[] clone = new char[n];        

        for (int i = 0; i < clone.Length; i++)
        {
            if (snake[i] == 'U')
            {
                clone[i] = 'D';                
            }
            else if (snake[i] == 'D')
            {
                clone[i] = 'U';                
            }
            else
            {
                clone[i] = snake[i];
            }
        }

        return new string(clone);        
    }
    

    static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());

        currentSnake = new char[n];

        GenerateSnakes(0, 0, 0, 'S');

        string result = string.Join(Environment.NewLine, snakes);
        Console.WriteLine(result);
        Console.WriteLine($"Snakes count = {snakes.Count}");
    }
}
