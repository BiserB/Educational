
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }    


    public ICommand ProcessCommand(IList<string> args)
    {
        string commandName = args[0] + Constants.Command;

        List<string> data = args.Skip(1).ToList();

        Assembly assembly = Assembly.GetExecutingAssembly();

        Type commandType = assembly.GetTypes()
            .FirstOrDefault(t => t.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));

        if (commandType == null)
        {
            throw new ArgumentException(Constants.InvalidCommand);
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(Constants.InvalidCommand);
        }

        PropertyInfo[] propToInject = commandType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                    .Where(p => p.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                                    .ToArray();

        object[] injectedArgs = propToInject.Select(p => this.serviceProvider.GetService(p.PropertyType)).ToArray();

        object[] arguments = new object[] { data }.Concat(injectedArgs).ToArray();

        ICommand command = (ICommand)Activator.CreateInstance(commandType, arguments);       

        return command;
    }
}
