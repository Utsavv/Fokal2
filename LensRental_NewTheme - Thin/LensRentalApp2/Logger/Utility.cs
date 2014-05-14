namespace Logger
{
    using System;
    using log4net;
    public class Utility
    {
        private static readonly ILog Log;

        static Utility()
        {
            Log = LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static void HandleException(string message)
        {
            Log.Error(message);
        }

        public static void HandleException(string message, Exception ex)
        {
            Log.Error(message, ex);
        }
        public static void WriteDebugData(string message)
        {
            Log.Debug(message);
        }

        public static void WriteInfo(string message)
        {
            Log.Info(message);
        }

    }
}