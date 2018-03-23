using Logger_Lib.Models.Contracts;
using Logger_Lib.Models.Factories;
using System;

namespace Exercise01_Logger
{
    public class Engine
    {
        private ILogger logger;

        public Engine(ILogger logger)
        {
            this.logger = logger;
        }

        public void Run(MessageFactory msgFactory)
        {
            string input = "";
            try
            {
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] data = input.Split('|');

                    string level = data[0];
                    string dateTime = data[1];
                    string content = data[2];

                    IMessage message = msgFactory.Create(dateTime, level, content);

                    logger.Log(message);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            LoggersInfo();
        }

        private void LoggersInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}