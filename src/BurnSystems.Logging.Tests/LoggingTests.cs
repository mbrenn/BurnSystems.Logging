using System.IO;
using BurnSystems.Logging.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BurnSystems.Logging.Tests
{
    [TestClass]
    public class LoggingTests
    {
        /// <summary>
        /// Stores the logger for the tests
        /// </summary>
        private readonly ClassLogger _logger = new ClassLogger(typeof(LoggingTests));

        [TestMethod]
        public void TestFramework()
        {
            var inMemoryProvider = new InMemoryDatabaseProvider();
            TheLog.AddProvider(inMemoryProvider, LogLevel.Trace);

            TheLog.Info("Test");
            TheLog.Trace("Test2");
            TheLog.Error("Test");
            
            Assert.AreEqual(3, inMemoryProvider.Messages.Count);
        }

        [TestMethod]
        public void TestFiltering()
        {
            var inMemoryProvider = new InMemoryDatabaseProvider();
            TheLog.AddProvider(inMemoryProvider, LogLevel.Info);

            TheLog.Info("Test");
            TheLog.Trace("Test2");
            TheLog.Error("Test");

            Assert.AreEqual(2, inMemoryProvider.Messages.Count);
        }

        [TestMethod]
        public void TestFilteringOfLog()
        {
            var inMemoryProvider = new InMemoryDatabaseProvider();
            TheLog.AddProvider(inMemoryProvider, LogLevel.Trace);
            TheLog.FilterThreshold = LogLevel.Info;

            TheLog.Info("Test");
            TheLog.Trace("Test2");
            TheLog.Error("Test");

            Assert.AreEqual(2, inMemoryProvider.Messages.Count);
        }

        [TestMethod]
        public void TestClassLogger()
        {
            var inMemoryProvider = new InMemoryDatabaseProvider();
            TheLog.AddProvider(inMemoryProvider, LogLevel.Info);
            TheLog.FilterThreshold = LogLevel.Info;

            _logger.Info("Test");
            _logger.Trace("Test2");
            _logger.Error("Test");

            Assert.AreEqual(2, inMemoryProvider.Messages.Count);
        }

        [TestMethod]
        public void TestConsoleLogger()
        {
            TheLog.AddProvider(new ConsoleProvider(), LogLevel.Info);
            _logger.Info("Info");   // will be shown
            _logger.Trace("Trace"); // will be ignored
            _logger.Error("Error"); // will be shown
        }

        [TestMethod]
        public void TestFileLogging()
        {
            using (var fileProvider = new FileProvider("./test.txt", true))
            {
                TheLog.AddProvider(fileProvider, LogLevel.Info);
                _logger.Info("Info");   // will be shown
                _logger.Trace("Trace"); // will be ignored
                _logger.Error("Error"); // will be shown
            }

            var lines = File.ReadAllLines("./test.txt");
            Assert.AreEqual(2, lines.Length);
            Assert.IsTrue(lines[0].Contains("Info"));
            Assert.IsTrue(lines[1].Contains("Error"));
            TheLog.ClearProviders();

            using (var fileProvider = new FileProvider("./test.txt", false))
            {
                TheLog.AddProvider(fileProvider, LogLevel.Info);
                _logger.Info("Info");   // will be shown
                _logger.Trace("Trace"); // will be ignored
                _logger.Error("Error"); // will be shown
            }

            lines = File.ReadAllLines("./test.txt");
            Assert.AreEqual(4, lines.Length);
            TheLog.ClearProviders();


            using (var fileProvider = new FileProvider("./test.txt", true))
            {
                TheLog.AddProvider(fileProvider, LogLevel.Info);
                _logger.Info("Info");   // will be shown
                _logger.Trace("Trace"); // will be ignored
                _logger.Error("Error"); // will be shown
            }

            lines = File.ReadAllLines("./test.txt");
            Assert.AreEqual(2, lines.Length);
            TheLog.ClearProviders();
        }
    }
}
