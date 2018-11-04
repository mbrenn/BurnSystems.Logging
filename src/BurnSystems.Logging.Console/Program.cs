using BurnSystems.Logging.Provider;

namespace BurnSystems.Logging.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TheLog.AddProvider(new ConsoleProvider(), LogLevel.Trace);
            TheLog.AddProvider(new FileProvider("test.log", true), LogLevel.Info);
            TheLog.Trace("Not added");
            TheLog.Debug("This is a debug message");
            TheLog.Info("We have an info message.");
            TheLog.Warn("We have a warn");
            TheLog.Error("Error Occured....");
            TheLog.Fatal("We have to quit the application due to loss of O².");

            new WorkingMan().Work();

            System.Console.WriteLine("Press key");
            System.Console.ReadKey();

        }
    }
}
