namespace _03BarracksFactory.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    internal class Engine : IRunnable
    {        
        private CommandInterpreter interpreter;

        public Engine(CommandInterpreter interpreter)
        {            
            this.interpreter = interpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    string[] data = input.Split();

                    string commandName = data[0];

                    IExecutable command = interpreter.InterpretCommand(data, commandName);

                    string result = command.Execute();

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        
    }
}