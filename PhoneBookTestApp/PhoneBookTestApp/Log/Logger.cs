using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp.Log
{
    public static class Logger
    {
        private static AbstractLogger baseLogger = null;

        public static void Log(LoggerType type, string source, string message)
        {
            switch (type)
            {
                case LoggerType.Console:
                    baseLogger = new ConsoleLogger();
                    break;
                case LoggerType.File:
                    baseLogger = new FileLogger();
                    break;
                default:
                    baseLogger = new FileLogger();
                    break;
            }
            baseLogger.Log(source, message);
        }
    }

    public enum LoggerType
    {
        File,
        Console
    }
}
