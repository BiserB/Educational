using System;
using System.Collections.Generic;
using System.Linq;

public class CircuitRace : Race
{
    private int laps;

    public CircuitRace(int length, string route, int prizePool, int laps) : base(length, route, prizePool)
    {
        Laps = laps;
    }

    public int Laps
    {
        get { return laps; }
        set { laps = value; }
    }

    private int PrizeCalc(int i)
    {
        switch (i)
        {
            case 1:
                return (int)(PrizePool * 0.4);

            case 2:
                return (int)(PrizePool * 0.3);

            case 3:
                return (int)(PrizePool * 0.2);

            case 4:
                return (int)(PrizePool * 0.1);

            default:
                return 0;
        }
    }

    public override string Finish()
    {
        DurabilityDecrease();
        List<Car> winners = Participants.OrderByDescending(c => c.OverallPerformance()).Take(4).ToList();

        string result = $"{Route} - {Length * Laps}" + Environment.NewLine;

        for (int i = 0; i < winners.Count; i++)
        {
            result += $"{i + 1}. {winners[i].Brand} {winners[i].Model} {winners[i].OverallPerformance()}PP - ${PrizeCalc(i + 1)}";
            if (i < winners.Count - 1)
            {
                result += Environment.NewLine;
            }
        }

        return result;
    }

    private void DurabilityDecrease()
    {
        int wear = Length * Length * Laps;
        foreach (Car car in Participants)
        {
            car.Durability -= wear;
        }
    }
}