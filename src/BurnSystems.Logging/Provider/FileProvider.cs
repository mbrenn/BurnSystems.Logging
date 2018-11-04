﻿using System;
using System.IO;

namespace BurnSystems.Logging.Provider
{
    public class FileProvider : ILogProvider, IDisposable
    {
        private readonly string _filePath;
        private readonly bool _createNew;
        private object _syncObject = new object();

        private StreamWriter _file;

        public FileProvider(string filePath, bool createNew = false)
        {
            _filePath = filePath;
            _createNew = createNew;
        }

        /// <summary>
        /// Logs the message into the given file. If the file is not open, it will be opened
        /// </summary>
        /// <param name="logMessage"></param>
        public void LogMessage(LogMessage logMessage)
        {
            lock (_syncObject)
            {
                if (_file == null)
                {
                    _file = new StreamWriter(_filePath, !_createNew);
                }

                _file.WriteLine($"{DateTime.Now};{logMessage.LogLevel};{logMessage.Category};{logMessage.Message}");
                _file.Flush();
            }
        }

        public void Dispose()
        {
            lock (_syncObject)
            {
                _file?.Dispose();
                _file = null;
            }
        }
    }
}