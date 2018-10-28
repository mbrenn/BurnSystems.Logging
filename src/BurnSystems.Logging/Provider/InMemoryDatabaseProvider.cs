using System;
using System.Collections.Generic;

namespace BurnSystems.Logging.Provider
{
    public class InMemoryDatabaseProvider : ILogProvider
    {
        private List<InMemoryLogMessage> _messages = 
            new List<InMemoryLogMessage>();

        /// <summary>
        /// Gets the messages that are received
        /// </summary>
        public List<InMemoryLogMessage> Messages => _messages;

        public void LogMessage(LogMessage logMessage)
        {
            _messages.Add(
                new InMemoryLogMessage()
                {
                    LogMessage = logMessage,
                    Created = DateTime.Now
                });
        }
    }
}