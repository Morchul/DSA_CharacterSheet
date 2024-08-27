using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Log
{
    public static LogLevel CurrentLogLevel { get; set; }

    public static void Calculation(string message)
    {
        InternLog(message, "green", LogLevel.Calculation);
    }

    public static void Verbose(string message)
    {
        InternLog(message, "white", LogLevel.Verbose);
    }

    public static void Debug(string message)
    {
        InternLog(message, "cyan", LogLevel.Debug);
    }

    public static void Warning(string message)
    {
        InternLog(message, "yellow", LogLevel.Warning);
    }

    public static void Error(string message)
    {
        InternLog(message, "red", LogLevel.Error);
    }

    private static void InternLog(string message, string color, LogLevel logLevel)
    {
        if (IsLogLevelActive(logLevel))
        {
            UnityEngine.Debug.Log($"<color={color}>" + message + "</color>");
        }
    }

    public static bool IsLogLevelActive(LogLevel logLevel) => (CurrentLogLevel & logLevel) > 0;

    [System.Flags]
    public enum LogLevel
    {
        Error = 0b1,
        Warning = 0b10,
        Debug = 0b100,
        Verbose = 0b1000,
        Calculation = 0b10000,

        Focus_Debug = 0b111,
        Focus_Calculation = 0b10011,
        All = 0b11111,
    }
}
