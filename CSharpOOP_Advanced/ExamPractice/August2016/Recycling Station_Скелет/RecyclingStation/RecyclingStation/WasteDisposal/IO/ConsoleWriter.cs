using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }    
}