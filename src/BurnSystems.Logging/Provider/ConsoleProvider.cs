using System;

namespace BurnSystems.Logging.Provider
{
    public class ConsoleProvider : ILogProvider
    {
        private readonly ConsoleColor[] _consoleColors = {
            ConsoleColor.DarkGray,
            ConsoleColor.Gray,
            ConsoleColor.Green,
            ConsoleColor.Yellow,
            ConsoleColor.Red,
            ConsoleColor.Magenta
        };

        private static readonly object SyncObject = new object();

        public void LogMessage(LogMessage logMessage)
        {
            lock (SyncObject)
            {
                var old = Console.ForegroundColor;
                Console.ForegroundColor = _consoleColors[(int) logMessage.LogLevel - 1];
                Console.WriteLine($"{DateTime.Now}: {logMessage}");
                Console.ForegroundColor = old;
            }
        }
    }
}