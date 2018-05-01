using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    public DayCommand(IList<string> arguments,
       IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }
    [Inject]
    public IHarvesterController HarvesterController { get; }
    [Inject]
    public IProviderController ProviderController { get; }

    public override string Execute()
    {
        string result = this.ProviderController.Produce();

        result += Environment.NewLine;

        result += this.HarvesterController.Produce();

        return result;
    }
}
