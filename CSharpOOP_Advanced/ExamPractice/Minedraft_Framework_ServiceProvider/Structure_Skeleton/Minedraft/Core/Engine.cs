using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private const string ShutdownCommand = "Shutdown";

    
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter)
    {        
        this.commandInterpreter = commandInterpreter;
        this.reader = new ConsoleReader();
        this.writer = new ConsoleWriter();
    }

    public void Run()
    {
        while (true)
        {
            var input = reader.ReadLine();

            var data = input.Split().ToList();
            
            ICommand command = commandInterpreter.ProcessCommand(data);

            string result = command.Execute();

            writer.WriteLine(result);

            if (input.Equals(ShutdownCommand,StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }
}
