using System;

enum LogLevel
{
    Info,
    Warning,
    Error
}

class Ques3
{
    public static void ParseLogLine(in string logLine, out DateTime timeStamp, out LogLevel level, ref int cnt)
    {
        cnt++;

        string[] parts = logLine.Split(' ');

        string dateTimeText = parts[0] + " " + parts[1];

        DateTime.TryParse(dateTimeText, out timeStamp);

        string logText = parts[2].Replace(":", "");

        Enum.TryParse(logText, true, out level);

    }

    public static void Start()
    {
        // string logLine = "2024-06-15 14:30:00 Info: Application started successfully.";
        string logLine = "2024-06-15 14:30:00 Error: Application Get Crashed!";

        DateTime timeStamp;
        LogLevel level;
        int count = 0;

        ParseLogLine(in logLine, out timeStamp, out level, ref count);

        Console.WriteLine("Parsed Log Line:");
        Console.WriteLine("Timestamp: " + timeStamp);
        Console.WriteLine("Log Level: " + level);
        Console.WriteLine("Count: " + count);
    }
}