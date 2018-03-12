using System;
using System.Collections.Generic;
using System.Linq;


public class StartUp
{
    static void Main()
    {
        var manager = new DraftManager();
        string input = "";
        string result = "";
        while ((input = Console.ReadLine())!= "Shutdown")
        {
            List<string> data = input.Split().ToList(); ;
            string command = data[0];           
            switch (command)
            {
                case "RegisterHarvester":
                    result = manager.RegisterHarvester(data.Skip(1).ToList());
                    break;
                case "RegisterProvider":
                    result = manager.RegisterProvider(data.Skip(1).ToList());
                    break;
                case "Day":
                    result = manager.Day();
                    break;
                case "Mode":
                    result = manager.Mode(data.Skip(1).ToList());
                    break;
                case "Check":
                    result = manager.Check(data.Skip(1).ToList());
                    break;                
            }
            Console.WriteLine(result);
        }
        result = manager.ShutDown();
        Console.WriteLine(result);
    }
    
}
