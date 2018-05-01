using System;
using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected IMissionController missionController;
    protected ICollection<string> args;
    protected ISoldierFactory soldierFactory;

    public Command(IMissionController missionController, ISoldierFactory soldierFactory, ICollection<string> args)
    {
        this.missionController = missionController;
        this.soldierFactory = soldierFactory;
        this.args = args;
    }

    public abstract string Execute();
}
