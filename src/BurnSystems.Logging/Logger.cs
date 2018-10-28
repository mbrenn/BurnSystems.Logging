﻿using System;
using System.Collections.Generic;

namespace BurnSystems.Logging
{
    public class Logger
    {
        /// <summary>
        /// Stores the list of providers
        /// </summary>
        private List<ProviderData> _providers = new List<ProviderData>();

        /// <summary>
        /// Gets or sets the log level threshold for the logging
        /// </summary>
        public LogLevel LogLevelThreshold { get; set; } = LogLevel.Info;

        /// <summary>
        /// Adds the provider being used for logging
        /// </summary>
        /// <param name="provider">Provider to be added</param>
        /// <param name="logLevelThreshold">Threshold of the log providers.
        /// LogMessage with a lower threshold will not be forwarded to the provider</param>
        public void AddProvider(ILogProvider provider, LogLevel logLevelThreshold)
        {
            var data = new ProviderData(provider,logLevelThreshold);
            _providers.Add(data);
        }

        /// <summary>
        /// Logs the level
        /// </summary>
        /// <param name="logLevel">The loglevel to be logged</param>
        /// <param name="category">Category of the</param>
        /// <param name="messageText">Message to be filtered</param>
        public void Log(LogLevel logLevel, string category, string messageText)
        {
            var message = new LogMessage
            {
                LogLevel = logLevel,
                Category = category,
                Message = messageText
            };

            Log(message);
        }

        private void Log(LogMessage message)
        {
            var logLevelDepth = (int) message.LogLevel;
            var threshold = (int) LogLevelThreshold;

            if (logLevelDepth < threshold)
            {
                // Do Nothing
                return;
            }

            // No go through each provider 
            foreach (var provider in _providers)
            {
                var providerLogLevel = (int) provider.LogLevelThreshold;
                if (logLevelDepth < providerLogLevel)
                {
                    continue;
                }

                provider.Provider.LogMessage(message);
            }

        }

        /// <summary>
        /// Stores the provider data being used in the logger
        /// </summary>
        private class ProviderData
        {
            public ProviderData(ILogProvider provider, LogLevel logLevelThreshold)
            {
                Provider = provider;
                LogLevelThreshold = logLevelThreshold;
            }

            public LogLevel LogLevelThreshold { get; set; }

            public ILogProvider Provider { get; set; }
        }
    }
}