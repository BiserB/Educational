using System;
using System.Linq;

public class TimeLimitRace : Race
{
    private int goldTime;

    public TimeLimitRace(int length, string route, int prizePool, int goldTime) : base(length, route, prizePool)
    {
        GoldTime = goldTime;
    }

    public int GoldTime
    {
        get { return goldTime; }
        set { goldTime = value; }
    }

    public override void AddCar(Car car)
    {
        if (Participants.Count == 0)
        {
            Participants.Add(car);
        }
    }

    public override string Finish()
    {
        var car = Participants.First();

        int timePerformance = Length * ((car.Horsepower / 100) * car.Acceleration);

        int prize = PrizePool / 2;
        string time = "Silver";

        if (timePerformance > GoldTime + 15)
        {
            prize = (PrizePool / 10) * 3;
            time = "Bronze";
        }
        else if (timePerformance <= GoldTime)
        {
            prize = PrizePool;
            time = "Gold";
        }

        string result = $"{Route} - {Length}" + Environment.NewLine;
        result += $"{car.Brand} {car.Model} - {timePerformance} s." + Environment.NewLine;
        result += $"{time} Time, ${prize}.";
        return result;
    }
}