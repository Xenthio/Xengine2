using System.Diagnostics;
using System.Reflection;

namespace Engine;

public static class Log
{
    public static void Info(string message) 
    {
        LogMessage(message, LogSeverity.Info, Assembly.GetCallingAssembly());
    }
    public static void Warning(string message) 
    {
        LogMessage(message, LogSeverity.Warning, Assembly.GetCallingAssembly());
    }
    public static void Error(string message) 
    {
        LogMessage(message, LogSeverity.Error, Assembly.GetCallingAssembly());
    }

    static void LogMessage(string message, LogSeverity severity, Assembly CallingAssembly)
    { 
        string CallingAssemblyName = CallingAssembly.GetName().Name ?? "Unknown";
        string SeverityLevel = severity.ToString();

        Console.WriteLine($"[{CallingAssemblyName}] [{SeverityLevel}]: {message}");
    }

    enum LogSeverity {
        Info,
        Warning,
        Error
    }
}