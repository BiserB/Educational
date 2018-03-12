using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly string END = "Cops Are Here";
    private CarManager manager = new CarManager();

    public void Run()
    {
        string inputData = Console.ReadLine();
        while (inputData != END)
        {
            CommandDistributor(inputData);
            inputData = Console.ReadLine();
        }
    }

    private void CommandDistributor(string inputData)
    {
        List<string> data = inputData.Split().ToList();
        Func<int> getId = () => int.Parse(data[1]);
        Func<int> getRace = () => int.Parse(data[2]);
        Func<int> getYear = () => int.Parse(data[5]);
        Func<int> getPower = () => int.Parse(data[6]);
        Func<int> getAcc = () => int.Parse(data[7]);
        Func<int> getSusp = () => int.Parse(data[8]);
        Func<int> getDur = () => int.Parse(data[9]);
        Func<int> getLength = () => int.Parse(data[3]);
        Func<int> getPrize = () => int.Parse(data[5]);
        int timeORlaps = 0;

        switch (data[0])
        {
            case "register":
                manager.Register(getId(), data[2], data[3], data[4], getYear(), getPower(), getAcc(), getSusp(), getDur());
                break;

            case "check":
                Console.WriteLine(manager.Check(getId()));
                break;

            case "open":
                if (data[2] == "Circuit" || data[2] == "TimeLimit")
                {
                    timeORlaps = int.Parse(data[6]);
                }
                manager.Open(getId(), data[2], getLength(), data[4], getPrize(), timeORlaps);
                break;

            case "participate":
                manager.Participate(getId(), getRace());
                break;

            case "start":
                Console.WriteLine(manager.Start(getId()));
                break;

            case "park":
                manager.Park(getId());
                break;

            case "unpark":
                manager.Unpark(getId());
                break;

            case "tune":
                manager.Tune(getId(), data[2]);
                break;

            default:
                break;
        }
    }
}