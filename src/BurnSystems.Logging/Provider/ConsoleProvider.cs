namespace BurnSystems.Logging.Provider
{
    public class ConsoleProvider : ILogProvider
    {
        public void LogMessage(LogMessage logMessage)
        {
            Debug.WriteLine($"{DateTime.Now}: {logMessage}");
        }
    }
}