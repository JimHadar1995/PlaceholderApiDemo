using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork {
    public enum LogLevel {
        Info,
        Error,
        Fatal
    }
    public interface ILogService {
        void Log(LogLevel logLevel, string message);
        void LogInfo(string message);
        void LogError(string message);
        void LogError(Exception e);
        void LogError(Exception e, string message);
        void LogFatal(string message);
        void LogFatal(Exception e);
        void LogFatal(Exception e, string message);
    }
}
