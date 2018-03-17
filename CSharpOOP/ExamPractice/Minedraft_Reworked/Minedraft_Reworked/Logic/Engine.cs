using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager manager;
        
    public Engine()
    {
        manager = new DraftManager();
    }

    public void Run()
    {       
        while (true)
        {
            string input = Console.ReadLine();
            CommandDistributor(input);
            if (input == "Shutdown")
            {
                break;
            }
        }
    }

    private void CommandDistributor(string input)
    {
        List<string> data = input.Split(' ').ToList();
        string result = "";

        switch (data[0])
        {
            case "RegisterHarvester":
                result = manager.RegisterHarvester(GetArgs(data));
                break;
            case "RegisterProvider":
                result = manager.RegisterProvider(GetArgs(data));
                break;
            case "Day":
                result = manager.Day();
                break;
            case "Mode":
                result = manager.Mode(GetArgs(data));
                break;
            case "Check":
                result = manager.Check(GetArgs(data));
                break;
            case "Shutdown":
                result = manager.ShutDown();
                break;            
        }

        Console.WriteLine(result);
    }

    private List<string> GetArgs(List<string> data)
    {
        List<string> arguments = data.Skip(1).ToList();
        return arguments;
    }
}
