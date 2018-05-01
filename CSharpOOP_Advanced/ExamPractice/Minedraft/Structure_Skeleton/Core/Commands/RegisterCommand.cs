using System;
using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> arguments,
       IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    { }

    public override string Execute()
    {
        string entityType = Arguments[0];
        string[] args = this.Arguments.Skip(1).ToArray();

        string result = Constants.InvalidEntity;

        if (entityType == nameof(Harvester))
        {
            result = this.HarvesterController.Register(args);
        }
        else if (entityType == nameof(Provider))
        {
            result = this.ProviderController.Register(args);
        }

        return result;
    }
}
