﻿using System;
using System.Collections.Generic;
using System.Linq;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override string Finish()
    {
        List<Car> winners = Participants.OrderByDescending(c => c.SuspensionPerformance()).Take(3).ToList();

        string result = $"{Route} - {Length}" + Environment.NewLine;

        for (int i = 0; i < winners.Count; i++)
        {
            result += $"{i + 1}. {winners[i].Brand} {winners[i].Model} {winners[i].SuspensionPerformance()}PP - ${CalcPrize(i + 1)}";
            if (i < winners.Count - 1)
            {
                result += Environment.NewLine;
            }
        }

        return result;
    }
}