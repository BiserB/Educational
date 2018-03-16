
using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private RaceTower tower = new RaceTower();    

    public void Run()
    {
        int raceLaps = int.Parse(Console.ReadLine());
        int lapLength = int.Parse(Console.ReadLine());

        tower.SetTrackInfo(raceLaps, lapLength);

        while (true)
        {
            string inputData = Console.ReadLine();
            CommandDistributor(inputData);            
        }
    }

    public void CommandDistributor(string inputData)
    {
        List<string> data = inputData.Split().ToList();
        string result = "";

        switch (data[0])
        {
            case "RegisterDriver":
                tower.RegisterDriver(data.Skip(1).ToList());
                break;
            case "Leaderboard":
                result = tower.GetLeaderboard();
                break;
            case "CompleteLaps":
                result = tower.CompleteLaps(data.Skip(1).ToList());                
                break;
            case "Box":
                tower.DriverBoxes(data.Skip(1).ToList());
                break;
            case "ChangeWeather":
                tower.ChangeWeather(data.Skip(1).ToList());
                break;
            default:
                result = "Invalid input!";
                break;
        }

        if (!string.IsNullOrWhiteSpace(result))
        {
            Console.WriteLine(result);
        }

        
    }
}
