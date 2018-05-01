using System;
using System.Text;

public class LastArmyMain
{
    static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        ISoldierFactory soldierFactory = new SoldiersFactory();
        IMissionFactory missionFactory = new MissionFactory();

        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();        
        IMissionController missionController = new MissionController(army, wareHouse);

        IGameController gameController = new GameController(missionController);

        IEngine engine = new Engine(reader, writer, ammunitionFactory, soldierFactory, missionFactory, gameController);

        engine.Run();
    }
}