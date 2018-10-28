using System;
using System.Diagnostics;

namespace BurnSystems.Logging.Provider
{
    public class DebugProvider: ILogProvider
    {
        public void LogMessage(LogMessage logMessage)
        {
            Debug.WriteLine($"{DateTime.Now}: {logMessage}");
        }
    }
}