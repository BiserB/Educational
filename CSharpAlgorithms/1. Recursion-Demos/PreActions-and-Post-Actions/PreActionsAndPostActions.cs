using System;

class PreActionsAndPostActions
{
    static void Main()
    {
        PrintFigure(5);
    }

    static void PrintFigure(int n)
    {
        if (n == 0)
        {
            // Bottom of the recursion
            return;
        }

        // Pre-action: print n asterisks
        Console.WriteLine(new string('*', n));

        // Recursive call: print figure of size n-1
        PrintFigure(n - 1);

        // Post-action: print n hashtags
        Console.WriteLine(new string('#', n));
    }
}
