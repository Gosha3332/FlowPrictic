using FlowPrictic.Models;
using FlowPrictic.Services;
using System.IO;

string path = @"E:\FlowPrictic\Logs";

if (!Directory.Exists(path))
{
    Console.WriteLine("Такого пути нет");
    return;
}

LogFileReader reader = new LogFileReader(path);
LogParser parser = new LogParser();
LogAnalyze analyzer = new LogAnalyze();

string[] files = await reader.GetLogFilesAsync();

foreach (string file in files)
{
    Console.WriteLine($"\n{Path.GetFileName(file)}");

    string[] lines = await reader.ReadFileAsync(file);

    List<LogEntry> entries = parser.Parse(lines);

    Dictionary<LogType, int> statistics = analyzer.Analyze(entries);

    Console.WriteLine($"INFO: {statistics[LogType.info]}");
    Console.WriteLine($"ERROR: {statistics[LogType.error]}");
    Console.WriteLine($"WARNING: {statistics[LogType.warning]}");
    Console.WriteLine($"INVALID: {statistics[LogType.invalid]}");
}
    