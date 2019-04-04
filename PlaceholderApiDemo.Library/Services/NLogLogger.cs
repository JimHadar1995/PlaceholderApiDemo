using FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceholderApiDemo.WebApi.App_Code {
    public class NLogLoggerService : ILogService {
        private NLog.ILogger _logger;
        public NLogLoggerService() {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }
        public void Log(LogLevel logLevel, string message) {
            switch (logLevel) {
                case LogLevel.Info:
                    default:
                    LogInfo(message);
                    break;
                case LogLevel.Error:
                    LogError(message);
                    break;
                case LogLevel.Fatal:
                    LogFatal(message);
                    break;
            }
        }

        public void LogError(string message) {
            _logger.Error(message);
        }

        public void LogError(Exception e, string message) {
            _logger.Error(e, message);
        }

        public void LogError(Exception e) {
            _logger.Error(e);
        }

        public void LogFatal(string message) {
            _logger.Fatal(message);
        }

        public void LogFatal(Exception e, string message) {
            _logger.Fatal(e, message);
        }

        public void LogFatal(Exception e) {
            _logger.Fatal(e);
        }

        public void LogInfo(string message) {
            _logger.Info(message);
        }
    }
}
