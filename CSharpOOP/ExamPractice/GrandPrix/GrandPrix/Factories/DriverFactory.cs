﻿
using System;
using System.Collections.Generic;

public static class DriverFactory
{
    public static Driver Create(List<string> args, Car car)
    {
        string type = args[0];
        string name = args[1];

        switch (type)
        {
            case "Aggressive":
                return new AggressiveDriver(name, car);
            case "Endurance":
                return new EnduranceDriver(name, car);
            default:
                throw new ArgumentException();
        }
    }
}