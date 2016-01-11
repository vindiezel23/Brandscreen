using System;
using System.Diagnostics;
using Castle.Core.Logging;

namespace Brandscreen.WebApi.Logging
{
    public class CastleToOwinLoggerAdapter : Microsoft.Owin.Logging.ILogger
    {
        private readonly ILogger _castleLogger;

        public CastleToOwinLoggerAdapter(ILogger castleLogger)
        {
            _castleLogger = castleLogger;
        }

        public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            var level = GetLogLevel(eventType);

            // According to docs http://katanaproject.codeplex.com/SourceControl/latest#src/Microsoft.Owin/Logging/ILogger.cs
            // "To check IsEnabled call WriteCore with only TraceEventType and check the return value, no event will be written."
            if (state == null)
            {
                return IsEnable(level);
            }
            if (!IsEnable(level))
            {
                return false;
            }

            Log(level, formatter(state, exception), exception);
            return true;
        }

        private static LoggerLevel GetLogLevel(TraceEventType traceEventType)
        {
            switch (traceEventType)
            {
                case TraceEventType.Critical:
                    return LoggerLevel.Fatal;
                case TraceEventType.Error:
                    return LoggerLevel.Error;
                case TraceEventType.Warning:
                    return LoggerLevel.Warn;
                case TraceEventType.Information:
                    return LoggerLevel.Info;
                case TraceEventType.Verbose:
                    return LoggerLevel.Debug;
                case TraceEventType.Start:
                    return LoggerLevel.Debug;
                case TraceEventType.Stop:
                    return LoggerLevel.Debug;
                case TraceEventType.Suspend:
                    return LoggerLevel.Debug;
                case TraceEventType.Resume:
                    return LoggerLevel.Debug;
                case TraceEventType.Transfer:
                    return LoggerLevel.Debug;
                default:
                    throw new ArgumentOutOfRangeException("traceEventType");
            }
        }

        private bool IsEnable(LoggerLevel level)
        {
            switch (level)
            {
                case LoggerLevel.Debug:
                    return _castleLogger.IsDebugEnabled;
                case LoggerLevel.Info:
                    return _castleLogger.IsInfoEnabled;
                case LoggerLevel.Warn:
                    return _castleLogger.IsWarnEnabled;
                case LoggerLevel.Error:
                    return _castleLogger.IsErrorEnabled;
                case LoggerLevel.Fatal:
                    return _castleLogger.IsFatalEnabled;
                default:
                    return false;
            }
        }

        private void Log(LoggerLevel level, string message, Exception exception)
        {
            switch (level)
            {
                case LoggerLevel.Debug:
                    _castleLogger.Debug(message, exception);
                    break;
                case LoggerLevel.Info:
                    _castleLogger.Info(message, exception);
                    break;
                case LoggerLevel.Warn:
                    _castleLogger.Warn(message, exception);
                    break;
                case LoggerLevel.Error:
                    _castleLogger.Error(message, exception);
                    break;
                case LoggerLevel.Fatal:
                    _castleLogger.Fatal(message, exception);
                    break;
            }
        }
    }
}