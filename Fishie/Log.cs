using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie
{
    public class Log
    {
        private static Log instance;
        private ILogger logger;

        private Log()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddConsole();
            });
             logger = loggerFactory.CreateLogger<Log>();
        }

        public static Log getInstance()
        {
            if (instance == null)
            {
                instance = new Log();
            }
            return instance;
        }
        public static void Trace(string message, params object[] args)
        {
            getInstance().logger.LogTrace(message, args);
        }
        public static void Debug(string message, params object[] args)
        {
            getInstance().logger.LogDebug(message, args);
        }
        public static void Info(string message, params object[] args)
        {
            getInstance().logger.LogInformation(message, args);
        }
        public static void Warn(string message, params object[] args)
        {
            getInstance().logger.LogWarning(message, args);
        }
        public static void Error(string message, params object[] args)
        {
            getInstance().logger.LogError(message, args);
        }
        public static void Critical(string message, params object[] args)
        {
            getInstance().logger.LogCritical(message, args);
        }
    }
}
