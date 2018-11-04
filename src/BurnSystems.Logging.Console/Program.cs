using BurnSystems.Logging.Provider;

namespace BurnSystems.Logging.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TheLog.AddProvider(new ConsoleProvider(), LogLevel.Info);
            TheLog.AddProvider(new FileProvider("test.log", true), LogLevel.Info);
            TheLog.Trace("Not added");
            TheLog.Info("We have an info message.");
            TheLog.Error("Error Occured....");
            TheLog.Fatal("We have to quit the application due to loss of O².");

            new WorkingMan().Work();
        }
    }
}
