using System;

namespace BurnSystems.Logging
{
    public class ClassLogger
    {
        private readonly string _category;

        public ClassLogger(Type type)
        {
            _category = type.FullName;
        }
        
        public void Trace(string message)
        {
            TheLog.Trace(message, _category);
        }

        public void Info(string message)
        {
            TheLog.Info(message, _category);
        }

        public void Fatal(string message)
        {
            TheLog.Fatal(message, _category);
        }

        public void Warn(string message)
        {
            TheLog.Warn(message, _category);
        }

        public void Error(string message)
        {
            TheLog.Error( message, _category);
        }
    }
}
