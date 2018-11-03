using System;

namespace BurnSystems.Logging.Provider
{
    public class ConsoleProvider : ILogProvider
    {
        private static object _syncObject = new object();

        public void LogMessage(LogMessage logMessage)
        {
            lock (_syncObject)
            {
                Console.WriteLine($"{DateTime.Now}: {logMessage}");
            }
        }
    }
}