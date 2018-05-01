﻿using System;
using System.Collections.Generic;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments,
        IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    { }
   
    public override string Execute()
    {
        string result = Constants.Result1;

        result += Environment.NewLine;

        result += string.Format(Constants.Result2, this.ProviderController.TotalEnergyProduced);

        result += Environment.NewLine;

        result += string.Format(Constants.Result3, this.HarvesterController.OreProduced); 

        return result;
    }
}
