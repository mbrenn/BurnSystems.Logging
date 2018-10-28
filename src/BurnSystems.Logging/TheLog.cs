namespace BurnSystems.Logging
{
    public static class TheLog
    {
        /// <summary>
        /// Stores the singleton of the logger
        /// </summary>
        private static readonly Logger _singleton = new Logger();

        /// <summary>
        /// Gets the singleton
        /// </summary>
        internal static Logger Singleton => _singleton;
    }
}