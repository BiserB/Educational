// Problem 4. Telephony
// You should have a model - Smartphone and two separate functionalities 
// - to call other phones and to browse in the world wide web. 

using System;

public class StartUp
{
    static void Main()
    {
        Smartphone smartphone = new Smartphone();
        string[] phoneNumbers = Console.ReadLine().Split();
        string[] sites = Console.ReadLine().Split();

        foreach (var number in phoneNumbers)
        {
            smartphone.MakeACall(number);            
        }
        foreach (var site in sites)
        {
            smartphone.BrowseTheWeb(site);
        }
    }
}