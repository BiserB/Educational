using System;
using System.Collections.Generic;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments,IProviderController providerController)
                  : base(arguments)
    {        
        this.ProviderController = providerController;
    }
    [Inject]
    public IProviderController ProviderController { get; }

    public override string Execute()
    {
        double value = double.Parse(Arguments[0]);

        string result = this.ProviderController.Repair(value);

        return result;
    }
}
