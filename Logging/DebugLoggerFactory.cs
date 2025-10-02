using System;

namespace pfin.Logging;

public static class DebugLoggerFactory
{
    private static bool _isDebugEnabled = false;

    public static IDebugLogger CreateLogger(Type type)
        => new DebugLogger(type.Name, _isDebugEnabled);


    private class DebugLogger : IDebugLogger
    {
        private readonly string _className;
        private readonly bool _isDebugEnabled;

        public DebugLogger(string className, bool isDebugEnabled)
        {
            _className = className;
            _isDebugEnabled = isDebugEnabled;
        }

        public void Log(string message)
        {
            if (_isDebugEnabled)
            {
                Console.WriteLine($"[DEBUG] - {_className} - {message}");
            }
        }
    }
}

