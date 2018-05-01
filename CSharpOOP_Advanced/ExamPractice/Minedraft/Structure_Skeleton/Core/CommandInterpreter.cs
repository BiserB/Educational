
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
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

        ConstructorInfo ctorInfo = commandType.GetConstructors().First();

        ParameterInfo[] paramInfo = ctorInfo.GetParameters();

        object[] arguments = new object[paramInfo.Length];

        for (int i = 0; i < paramInfo.Length; i++)
        {
            Type paramType = paramInfo[i].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                arguments[i] = data;
            }
            else
            {
                PropertyInfo[] currentProperties = this.GetType().GetProperties();

                PropertyInfo selectedProperty = currentProperties.First(p => p.PropertyType == paramType);

                arguments[i] = selectedProperty.GetValue(this);
            }            
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, arguments); 

        string result = command.Execute();

        return result;
    }
}
