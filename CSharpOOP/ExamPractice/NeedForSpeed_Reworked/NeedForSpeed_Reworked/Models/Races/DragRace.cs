using System;
using System.Collections.Generic;
using System.Linq;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override string Finish()
    {
        List<Car> winners = Participants.OrderByDescending(c => c.EnginePerformance()).Take(3).ToList();

        string result = $"{Route} - {Length}" + Environment.NewLine;

        for (int i = 0; i < winners.Count; i++)
        {
            result += $"{i + 1}. {winners[i].Brand} {winners[i].Model} {winners[i].EnginePerformance()}PP - ${CalcPrize(i + 1)}";
            if (i < winners.Count - 1)
            {
                result += Environment.NewLine;
            }
        }

        return result;
    }
}