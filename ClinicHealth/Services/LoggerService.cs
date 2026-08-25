namespace ClinicHealth.Services;

public class LoggerService
{
    private readonly string _logFilePath;

    public LoggerService(string logFilePath = "clinic_errors.log")
    {
        _logFilePath = logFilePath;
    }

    public void LogError(Exception ex, string context = "")
    {
        string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR";
        
        if (!string.IsNullOrEmpty(context))
        {
            logMessage += $" | Context: {context}";
        }
        
        logMessage += $" | Message: {ex.Message}";
        logMessage += $" | Type: {ex.GetType().Name}";
        
        if (ex.InnerException != null)
        {
            logMessage += $" | Inner: {ex.InnerException.Message}";
        }
        
        logMessage += $" | StackTrace: {ex.StackTrace}";
        
        Console.WriteLine(logMessage);
        
        try
        {
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
        catch
        {
            Console.WriteLine("Warning: Could not write to log file.");
        }
    }

    public void LogInfo(string message)
    {
        string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO | {message}";
        Console.WriteLine(logMessage);
        
        try
        {
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
        catch
        {
            Console.WriteLine("Warning: Could not write to log file.");
        }
    }

    public void LogWarning(string message)
    {
        string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] WARNING | {message}";
        Console.WriteLine(logMessage);
        
        try
        {
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
        catch
        {
            Console.WriteLine("Warning: Could not write to log file.");
        }
    }
}
