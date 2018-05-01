using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    public DayCommand(IList<string> arguments,
       IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    { }

    public override string Execute()
    {
        string result = this.ProviderController.Produce();

        result += Environment.NewLine;

        result += this.HarvesterController.Produce();

        return result;
    }
}
