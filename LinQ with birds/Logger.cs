using Testing;

public static class Logger
{
    private static readonly string LogFilePath = Program.LastSessionLog;

    public static void Log(string message)
    {
        EnsureLogFileExists();
        string logEntry = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}]:\n{message}\n";
        File.AppendAllText(LogFilePath, logEntry);
    }

    private static void EnsureLogFileExists()
    {
        if (!File.Exists(LogFilePath))
        {
            using (File.Create(LogFilePath)) { }
        }
    }
}