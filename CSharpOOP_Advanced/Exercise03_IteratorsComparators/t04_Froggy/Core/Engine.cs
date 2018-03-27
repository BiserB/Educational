using System;
using System.Linq;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private Lake lake;

    public Engine(IReader reader, IWriter writer, params int[] numbers)
    {
        this.reader = reader;
        this.writer = writer;
        lake = new Lake(numbers);
    }

    public void Run()
    {
        string result = string.Join(", ", lake);

        writer.WriteLine(result);
    }
}