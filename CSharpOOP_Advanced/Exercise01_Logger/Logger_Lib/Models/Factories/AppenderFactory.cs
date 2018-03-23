using Logger_Lib.Models.Contracts;
using Logger_Lib.Models.Enums;
using System;

namespace Logger_Lib.Models.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory lf;
        private FileFactory fileFact;
        private int fileCounter;
        private string defaultName = "Log{0}.txt";

        public AppenderFactory(LayoutFactory layoutFactory, FileFactory fileFactory)
        {
            lf = layoutFactory;
            fileFact = fileFactory;
        }

        public IAppender Create(string appenderType, string layoutType, string messageLevel)
        {
            ILayout layout = lf.Create(layoutType);

            MessageLevel level = MessageLevel.INFO;

            Enum.TryParse(messageLevel, true, out level);

            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, level);

                case "FileAppender":
                    fileCounter++;
                    string fileName = string.Format(defaultName, fileCounter);
                    ILogFile logFile = fileFact.Create(fileName);
                    return new FileAppender(layout, level, logFile);

                default:
                    throw new ArgumentException("Wrong appender type!");
            }
        }
    }
}