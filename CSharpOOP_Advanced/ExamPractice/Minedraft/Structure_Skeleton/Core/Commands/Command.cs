using System;
using System.Collections.Generic;

public abstract class Command : ICommand
{
    public Command(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
    {
        this.Arguments = arguments;
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IList<string> Arguments { get; }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public abstract string Execute();
}
