
namespace _03BarracksFactory.Core
{
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core.Commands;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IRepository repo, IUnitFactory unitFact, IServiceProvider serviceProvider)
        {
            this.repository = repo;
            this.unitFactory = unitFact;
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command!");
            }
            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandType} is not a command type!");
            }

            FieldInfo[] fieldsToInject = commandType
                                        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                        .Where(f => f.CustomAttributes.Any(atr => atr.AttributeType == typeof(InjectAttribute)))
                                        .ToArray();

            object[] injectArgs = fieldsToInject
                                 .Select(f => this.serviceProvider.GetService(f.FieldType))
                                 .ToArray();

            object[] commandArgs = new object[] { data }.Concat(injectArgs).ToArray();

            IExecutable newCommand = (IExecutable)Activator.CreateInstance(commandType, commandArgs);
            
            return newCommand;
        }
    }
}
