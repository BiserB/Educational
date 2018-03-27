using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        int[] numbers = Console.ReadLine()
                               .Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

        Engine engine = new Engine(reader, writer, numbers);

        engine.Run();
    }
}
