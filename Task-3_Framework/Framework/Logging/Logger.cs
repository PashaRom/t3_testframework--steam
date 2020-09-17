using System;
using NLog;

namespace App.Framework.Logging
{
    public static class AppLog
    {
        private static Logger WriteLog;
        static AppLog() {
            WriteLog = LogManager.GetCurrentClassLogger();
        }

        public static void Trace (string message) {
            WriteLog.Trace(message);
        }
        public static void Debug(Exception exception,string message) {
            WriteLog.Debug(exception, message);
        }
        public static void Info(string message) {
            WriteLog.Info(message);
        }
        public static void Error(Exception exception, string message) {
            WriteLog.Error(exception, message);
        }
         public static void Error(string message) {
            WriteLog.Error(message);
        }
        public static void Fatal (Exception exception, string message) {
            WriteLog.Fatal(exception, message);
        }
        public static void Warn(string message){
            WriteLog.Warn(message);
        }
    }
}
