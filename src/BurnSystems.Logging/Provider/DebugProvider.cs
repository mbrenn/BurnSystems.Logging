using System;
using System.Diagnostics;

namespace BurnSystems.Logging.Provider
{
    public class DebugProvider: ILogProvider
    {
        private static object _syncObject = new object();


        public void LogMessage(LogMessage logMessage)
        {
            lock (_syncObject)
            {
                Debug.WriteLine($"{DateTime.Now}: {logMessage}");
            }
        }
    }
}