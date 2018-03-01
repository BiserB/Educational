// Create a class DateModifier which stores the difference of the days between two dates.

using System;

public class Program
{
    static void Main()
    {        
        string date1 = Console.ReadLine();
        string date2 = Console.ReadLine();
        var datediff = new DateModifier();
        Console.WriteLine(datediff.Difference(date1, date2)); 
    }
}
