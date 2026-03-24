using System;

namespace RoundEndGravity;

public static class Log
{
    public static void Info(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"[RoundEndGravity] {message}");
        Console.ResetColor();
    }
}
