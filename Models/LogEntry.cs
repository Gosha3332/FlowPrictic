namespace FlowPrictic.Models
{
    public class LogEntry
    {
        public LogEntry(LogType tupe, string message, DateTime date)
        {
            Type = tupe;
            Message = message;
            Date = date;
        }

        public LogType Type { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }

    public enum LogType 
    {
        warning,
        error,
        info,
        invalid
    }
}
