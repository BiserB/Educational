using System;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        IServiceProvider serviceProvider = ConfigureServices();

        ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

        Engine engine = new Engine(commandInterpreter);

        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<IEnergyRepository, EnergyRepository>();
        services.AddSingleton<IProviderController, ProviderController>();
        services.AddSingleton<IHarvesterController, HarvesterController>();
       
        services.AddSingleton<IReader, ConsoleReader>();
        services.AddSingleton<IWriter, ConsoleWriter>();

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }
}