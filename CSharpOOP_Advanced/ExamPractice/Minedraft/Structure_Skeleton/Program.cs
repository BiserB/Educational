public class Program
{
    public static void Main(string[] args)
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        ProviderController providerController = new ProviderController(energyRepository);
        HarvesterController harvesterController = new HarvesterController(energyRepository);
        CommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        Engine engine = new Engine(commandInterpreter, reader, writer);

        engine.Run();
    }
}