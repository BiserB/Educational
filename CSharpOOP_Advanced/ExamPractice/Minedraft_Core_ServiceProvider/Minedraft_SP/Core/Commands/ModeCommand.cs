﻿using System;
using System.Collections.Generic;

public class ModeCommand : Command
{
    public ModeCommand(IList<string> arguments,
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
        string mode = Arguments[0];

        string result = this.HarvesterController.ChangeMode(mode);

        return result;
    }
}
