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
        private ClassLogger _logger = new ClassLogger(typeof(LoggingTests));

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
    }
}
