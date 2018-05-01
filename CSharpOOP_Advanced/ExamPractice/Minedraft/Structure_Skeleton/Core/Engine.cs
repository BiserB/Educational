using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private const string ShutdownCommand = "Shutdown";

    
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)    {
        
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            var input = reader.ReadLine();

            var data = input.Split().ToList();
            
            string result = commandInterpreter.ProcessCommand(data);

            writer.WriteLine(result);

            if (input.Equals(ShutdownCommand,StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }
}
