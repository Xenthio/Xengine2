using System.Diagnostics;
using System.Reflection;

namespace Engine;

public static class Log
{
    public static void Info(string message) 
    {
        LogMessage(message, LogSeverity.Info);
    }
    public static void Warning(string message) 
    {
        LogMessage(message, LogSeverity.Warning);
    }
    public static void Error(string message) 
    {
        LogMessage(message, LogSeverity.Error);
    }

    static void LogMessage(string message, LogSeverity severity)
    { 
        string CallingAssembly = Assembly.GetCallingAssembly().GetName().Name ?? "Unknown";
        string SeverityLevel = severity.ToString();

        Console.WriteLine($"[{CallingAssembly}] [{SeverityLevel}]: {message}");
    }

    enum LogSeverity {
        Info,
        Warning,
        Error
    }
}