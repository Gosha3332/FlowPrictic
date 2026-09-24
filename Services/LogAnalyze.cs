using FlowPrictic.Models;

namespace FlowPrictic.Services
{
    public class LogAnalyze
    {
        public Dictionary<LogType, int> Analyze(List<LogEntry> entries)
        {
            var result = new Dictionary<LogType, int>
            {
                [LogType.info] = 0,
                [LogType.error] = 0,
                [LogType.warning] = 0,
                [LogType.invalid] = 0
            };

            foreach (var entry in entries)
            {
                result[entry.Type]++;
            }

            return result;
        }
    }
}
