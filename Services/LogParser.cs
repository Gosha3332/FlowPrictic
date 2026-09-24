using FlowPrictic.Models;
using System.Collections.Concurrent;

namespace FlowPrictic.Services
{
    public class LogParser
    {
        public List<LogEntry> Parse(string[] lines)
        {
            ConcurrentBag<LogEntry> result = new ConcurrentBag<LogEntry>();

            Parallel.ForEach(lines, line =>
            {
                string[] parts = line.Split(' ', 4);

                if (!IsValidFormat(parts))
                {
                    result.Add(new LogEntry(LogType.invalid,line,DateTime.MinValue));

                    return;
                }

                DateTime date = DateTime.Parse($"{parts[0]} {parts[1]}");

                LogType type = parts[2] switch
                {
                    "[WARNING]" => LogType.warning,
                    "[ERROR]" => LogType.error,
                    "[INFO]" => LogType.info,
                };

                result.Add(new LogEntry(type, parts[3], date));
            });

            return result.ToList();
        }
        private bool IsValidFormat(string[] parts)
        {
            if (parts.Length < 4)
                return false;

            if (!DateTime.TryParse($"{parts[0]} {parts[1]}", out _))
                return false;

            if (parts[2] != "[INFO]" &&
                parts[2] != "[ERROR]" &&
                parts[2] != "[WARNING]")
                return false;

            if (string.IsNullOrWhiteSpace(parts[3]))
                return false;

            return true;
        }
    }


}
