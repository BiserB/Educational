using System;
using System.Reflection;

public class Program
{
    static void Main()
    {
        Spy spy = new Spy();

        string result = spy.StealFieldInfo("Hacker", "username", "password");

        Console.WriteLine(result);
    }
}
