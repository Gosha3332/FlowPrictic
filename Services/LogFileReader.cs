namespace FlowPrictic.Services
{
    public class LogFileReader
    {
        public LogFileReader(string patch)
        {
            Patch = patch;
        }

        public string Patch { get; private set; }

        public Task<string[]> GetLogFilesAsync()
        {
            return Task.FromResult(Directory.GetFiles(Patch, "*.log"));
        }

        public async Task<string[]> ReadFileAsync(string filePath)
        {
            return await File.ReadAllLinesAsync(filePath);
        }

    }
}
