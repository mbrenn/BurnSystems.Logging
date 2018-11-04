using System;
using System.Diagnostics;

namespace BurnSystems.Logging.Provider
{
    public class DebugProvider: ILogProvider
    {
        private static readonly object SyncObject = new object();
        
        public void LogMessage(LogMessage logMessage)
        {
            lock (SyncObject)
            {
                Debug.WriteLine($"{DateTime.Now}: {logMessage}");
            }
        }
    }
}