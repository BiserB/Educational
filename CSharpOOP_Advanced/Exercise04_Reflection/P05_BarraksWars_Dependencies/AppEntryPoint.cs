namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    internal class AppEntryPoint
    {
        private static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            CommandInterpreter interpreter = new CommandInterpreter(repository, unitFactory, serviceProvider);

            IRunnable engine = new Engine(interpreter);

            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IUnitFactory, UnitFactory>();
            services.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}