
using System;
using System.Collections.Generic;

public static class TyreFactory
{
    public static Tyre Create(List<string> args)
    {        
        string tyreType = args[4];
        double tyreHardness = double.Parse(args[5]);

        switch (tyreType)
        {
            case "Ultrasoft":
                double grip = double.Parse(args[6]);
                return new UltrasoftTyre(tyreHardness, grip);
            case "Hard":                
                return new HardTyre(tyreHardness);
            default:
                throw new ArgumentException();                
        }
    }
}
