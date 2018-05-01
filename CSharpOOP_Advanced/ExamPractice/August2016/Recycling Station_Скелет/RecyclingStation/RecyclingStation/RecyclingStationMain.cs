
public class RecyclingStationMain
{
    private static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
       
        IStrategyHolder strategyHolder = new StrategyHolder();

        IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);

        IWasteFactory wasteFactory = new WasteFactory();

        IRecyclingManager recyclingManager = new RecyclingManager(garbageProcessor, wasteFactory);

        IEngine engine = new Engine(reader, writer, recyclingManager);

        engine.Run();
    }
}
