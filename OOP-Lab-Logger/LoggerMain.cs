using Logger.Interfaces;
using Logger.Layouts;
using Logger.Appenders;
using System;

namespace Logger
{
    class LoggerMain
    {
        static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();

            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            string filePath = "log.txt";
            IAppender fileAppender = new FileAppender(filePath, simpleLayout);

            ILogger logger = new Logger(consoleAppender, fileAppender);
            logger.Error("Error parsing JSON.");
            logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
            logger.Warn("Warning - missing files.");

            Console.WriteLine();

            var xmlLayout = new XMLLayout();
            consoleAppender.Layout = xmlLayout;

            logger.Fatal("mscorlib.dll does not respond");
            logger.Critical("No connection string found in App.config");

            Console.WriteLine();

            consoleAppender.Layout = simpleLayout;
            logger.ReportLevel = ReportLevel.Critical;
            logger.Info("Everything seems fine");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");

        }
    }
}
