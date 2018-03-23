using Logger_Lib.Models;
using Logger_Lib.Models.Contracts;
using Logger_Lib.Models.Factories;
using System;
using System.Collections.Generic;

namespace Exercise01_Logger
{
    public class StartUp
    {
        private static void Main()
        {
            ILogger logger = CreateLogger();

            MessageFactory msgFactory = new MessageFactory();

            Engine engine = new Engine(logger);

            engine.Run(msgFactory);
        }

        private static ILogger CreateLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            FileFactory fileFactory = new FileFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory, fileFactory);

            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                string[] args = Console.ReadLine().Split();
                string appenderType = args[0];
                string layoutType = args[1];
                string level = "";
                if (args.Length == 3)
                {
                    level = args[2];
                }

                IAppender appender = appenderFactory.Create(appenderType, layoutType, level);

                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}