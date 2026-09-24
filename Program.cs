using System.IO;

string path = "E:\\FlowPrictic\\Logs\\";

if (!Directory.Exists(path))
{
    Console.WriteLine("Такого пути нет");
    return;
}

string[] logFiles = Directory.GetFiles(path, "*.log");

foreach (string log in logFiles)
{
    Console.WriteLine($"\n{Path.GetFileName(log)}");

    Dictionary<string, int> LogAnalyze = new Dictionary<string, int>
    {
        ["[INFO]"] = 0,
        ["[ERROR]"] = 0,
        ["[WARNING]"] = 0
    };
    string[] lines = File.ReadAllLines(log);

    foreach (string line in lines)
    {
        foreach (string type in LogAnalyze.Keys)
        {
            if (line.Contains(type))
            {
                LogAnalyze[type]++;
                break;
            }
        }
    }
    Console.WriteLine($"INFO: {LogAnalyze["[INFO]"]}");
    Console.WriteLine($"ERROR: {LogAnalyze["[ERROR]"]}");
    Console.WriteLine($"WARNING: {LogAnalyze["[WARNING]"]}");
}