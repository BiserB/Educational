using System;
using System.Collections.Generic;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments,
       IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    { }

    public override string Execute()
    {
        double value = double.Parse(Arguments[0]);

        string result = this.ProviderController.Repair(value);

        return result;
    }
}
