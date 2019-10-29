using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxisCheat.Axis.SDK.Manager
{
    class HashLog
    {
        private static string LogPath = "";
        private static StringBuilder sb = new StringBuilder();

        public enum LogLevel
        {
            TRACE,
            INFO,
            DEBUG,
            WARNING,
            ERROR,
            FATAL
        }

        public HashLog(string path)
        {
            LogPath = path;
            Write("[LOG - " + Date() + "]" + Environment.NewLine);
        }

        private string Date()
        {
            return DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }

        public void Write(string text)
        {
            sb.AppendLine(text);
            Console.WriteLine(text);
        }

        public void Write(string text, LogLevel log)
        {
            Write("[" + log.ToString() + "] " + text);
        }

        #region other
        public void Debug(string text)
        {
            Write(text, LogLevel.DEBUG);
        }

        public void Error(string text)
        {
            Write(text, LogLevel.ERROR);
        }

        public void Fatal(string text)
        {
            Write(text, LogLevel.FATAL);
        }

        public void Info(string text)
        {
            Write(text, LogLevel.INFO);
        }

        public void Trace(string text)
        {
            Write(text, LogLevel.TRACE);
        }

        public void Warning(string text)
        {
            Write(text, LogLevel.WARNING);
        }
        #endregion

        public void Save()
        {
            using (FileStream fs = new FileStream(LogPath, FileMode.OpenOrCreate, FileAccess.ReadWrite)) { fs.Close(); }
            File.WriteAllText(LogPath, sb.ToString());
        }
    }
}
