using System;


[SoftUni("Ventsi")]
public class StartUp
{
    [SoftUni("Gosho")]
    static void Main(string[] args)
    {
        var tracker = new Tracker();

        tracker.PrintMethodsByAuthor();
    }

    [SoftUni("Gosho")]
    void TestMethod()
    {

    }
}