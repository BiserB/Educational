
using System;
using System.Linq;
using System.Reflection;

public class Engine : IEngine
{
    private const string END_MESSAGE = "TimeToRecycle";

    private IReader reader;
    private IWriter writer;
    private IRecyclingManager recyclingManager;
    

    private MethodInfo[] recyclingManagerMethods;

    public Engine(IReader reader, IWriter writer, IRecyclingManager recyclingManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.recyclingManager = recyclingManager;
        

        this.recyclingManagerMethods = this.recyclingManager.GetType().GetMethods();
    }

    public void Run()
    {
        string input = reader.ReadLine();

        while (input != END_MESSAGE)
        {
            string[] args = input.Split(' ');

            string methodName = args[0];

            string[] garbageArgs = null;

            if (args.Length > 1)
            {
                garbageArgs = args[1].Split('|');
            }            

            MethodInfo methodToInvoke = this.recyclingManagerMethods
                                            .First(m => m.Name == methodName);

            ParameterInfo[] methodParams = methodToInvoke.GetParameters();

            object[] parsedParams = new object[methodParams.Length];

            for (int index = 0; index < parsedParams.Length; index++)
            {
                Type paramType = methodParams[index].ParameterType;

                string toConvert = garbageArgs[index];

                parsedParams[index] = Convert.ChangeType(toConvert, paramType);
            }

            string result = methodToInvoke.Invoke(this.recyclingManager, parsedParams).ToString();

            this.writer.WriteLine(result);

            input = reader.ReadLine();
        }
    }
}