using System;
using System.Linq;

public class Smartphone : ICall, IBrowse
{ 
    public void MakeACall(string number)
    {
        if (number.All(ch => Char.IsDigit(ch)))
        {
            Console.WriteLine($"Calling... {number}");
        }
        else
        {
            Console.WriteLine("Invalid number!");
        }
    }

    public void BrowseTheWeb(string site)
    {
        if (site.Any(ch => Char.IsDigit(ch)))
        {
            Console.WriteLine("Invalid URL!");
        }
        else
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
