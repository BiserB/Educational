
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private readonly int BOX_TIME = 20;
    public Track track;
    private List<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;

    public RaceTower()
    {
        racingDrivers = new List<Driver>();
        failedDrivers = new Stack<Driver>();
    }    

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        track = new Track(lapsNumber, trackLength);
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Tyre tyre = TyreFactory.Create(commandArgs);
            Car car = CarFactory.Create(commandArgs, tyre);
            Driver driver = DriverFactory.Create(commandArgs, car);
            string name = commandArgs[1];
            racingDrivers.Add(driver);
        }
        catch (ArgumentException)
        { } 
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string action = commandArgs[0];
        string name = commandArgs[1];

        Driver driver = racingDrivers.FirstOrDefault(d => d.Name == name);

        driver.AddTime(BOX_TIME);

        if (action == "Refuel")
        {
            double fuel = double.Parse(commandArgs[2]);
            driver.Car.Refuel(fuel);
        }
        else if (action == "ChangeTyres")
        {
            double hardness = double.Parse(commandArgs[3]);
            switch (commandArgs[2])
            {                
                case "Hard":                    
                    HardTyre hardTyre = new HardTyre(hardness);
                    driver.Car.ChangeTyre(hardTyre);
                    break;
                case "Ultrasoft":
                    double grip = double.Parse(commandArgs[4]);
                    UltrasoftTyre softTyre = new UltrasoftTyre(hardness, grip);
                    driver.Car.ChangeTyre(softTyre);
                    break;
            }
        }        
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int laps = int.Parse(commandArgs[0]);
        int remainingLaps = track.RaceLaps - track.CurrentLap;
        if (laps > remainingLaps)
        {
            return ($"There is no time! On lap {track.CurrentLap}.");
        }        

        StringBuilder sb = new StringBuilder();

        for (int i = 1; i <= laps; i++)
        {
            track.CurrentLap++;

            MakeLap();

            sb.AppendLine(Overtaking());
        }

        if (track.CurrentLap == track.RaceLaps)
        {
            sb.AppendLine(Finish().Trim());
        }

        return sb.ToString().Trim();
    }

    private void MakeLap()
    {
        for (int i = 0; i < racingDrivers.Count; i++)
        {
            try
            {
                racingDrivers[i].CompleteLap(track.Length);
            }
            catch (ArgumentException ae)
            {
                racingDrivers[i].Fail(ae.Message);
                failedDrivers.Push(racingDrivers[i]);
                racingDrivers.RemoveAt(i);
                i--;
            }
        }
    }

    private string Overtaking()
    {
        StringBuilder sb = new StringBuilder();

        var orderedDrivers = racingDrivers.OrderByDescending(d => d.TotalTime).ToList();

        for (int i = 0; i < orderedDrivers.Count - 1; i++)
        {
            int interval = 2;
            var slowestDriver = orderedDrivers[i];
            var fastestDriver = orderedDrivers[i + 1];

            bool agressiveSoft = slowestDriver is AggressiveDriver && slowestDriver.Car.Tyre is UltrasoftTyre;
            bool enduranceHard = slowestDriver is EnduranceDriver && slowestDriver.Car.Tyre is HardTyre;
            bool crashed = (agressiveSoft && track.Weather == Weather.Foggy) || (enduranceHard && track.Weather == Weather.Rainy);

            if (agressiveSoft || enduranceHard)
            {
                interval = 3;
            }

            if (fastestDriver.TotalTime + interval >= slowestDriver.TotalTime)
            {
                if (crashed)
                {
                    slowestDriver.Fail("Crashed");
                    failedDrivers.Push(slowestDriver);
                    racingDrivers.Remove(slowestDriver);                                        
                }
                else
                {
                    fastestDriver.AddTime(interval);
                    slowestDriver.ReduceTime(interval);
                    i++;
                    sb.AppendLine($"{slowestDriver.Name} has overtaken {fastestDriver.Name} on lap {track.CurrentLap}.");
                }                
            }
        }

        return sb.ToString().TrimEnd();
    }        
    
    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {track.CurrentLap}/{track.RaceLaps}");

        List<Driver> allDrivers = racingDrivers
                                  .OrderBy(d => d.TotalTime)
                                  .Concat(failedDrivers).ToList();
        int position = 1;

        foreach (var driver in allDrivers)
        {
            sb.AppendLine($"{position} {driver.ToString()}");
            position++;
        }
        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {        
        if (Enum.TryParse(commandArgs[0], out Weather newWeather))
        {
            track.SetWeather(newWeather);
        }
    }

    public string Finish()
    {
        Driver winner = racingDrivers.OrderBy(d => d.TotalTime).First();
        return $"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.";
    }
}
