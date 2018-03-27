using System;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string result)
    {
        Console.WriteLine(result);
    }
}
