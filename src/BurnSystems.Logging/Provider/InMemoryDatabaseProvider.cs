using System;
using System.Collections.Generic;

namespace BurnSystems.Logging.Provider
{
    public class InMemoryDatabaseProvider : ILogProvider
    {
        /// <summary>
        /// Stores a singleton that can be used by simple applications
        /// </summary>
        public static InMemoryDatabaseProvider TheOne { get; }= new InMemoryDatabaseProvider();
        
        private List<InMemoryLogMessage> _messages = 
            new List<InMemoryLogMessage>();

        /// <summary>
        /// Gets the messages that are received
        /// </summary>
        public List<InMemoryLogMessage> Messages => _messages;

        public void LogMessage(LogMessage logMessage)
        {
            lock (_messages)
            {
                _messages.Add(
                    new InMemoryLogMessage()
                    {
                        LogMessage = logMessage,
                        Created = DateTime.Now
                    });
            }
        }
        
        public void ClearLog()
        {
            lock (_messages)
            {
                _messages.Clear();
            }
        }
    }
}