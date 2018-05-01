using System;
using System.Collections.Generic;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private IAmmunitionFactory ammunitionFactory;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;

    private IGameController gameController;

    public Engine(IReader reader, IWriter writer, IAmmunitionFactory ammunitionFactory,
        ISoldierFactory soldierFactory, IMissionFactory missionFactory, IGameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.ammunitionFactory = ammunitionFactory;
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
        this.gameController = gameController;
    }

    public void Run()
    {
        while (true)
        {
            string[] args = reader.ReadLine().Split();

            string result = gameController.ProcessCommand(args);

            writer.WriteLine(result);
        }
    }
}
