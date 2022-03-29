namespace ToH.Log;

public class FileLog : ILog
{
    private StreamWriter _file;

    public FileLog(string filepath, bool append)
    {
        _file = new StreamWriter(filepath, append);
        _file.AutoFlush= true;

        Info("Logger initialized.");
    }

    private void Log(string level, string line)
    {
        _file.WriteLine($"{DateTime.Now} - {level} - {line}");
    }

    public void Debug(string line)
    {
        Log("DEBUG", line);
    }

    public void Error(string line)
    {
        Log("ERROR", line);
    }

    public void Info(string line)
    {
        Log("INFO", line);
    }

    public void Warn(string line)
    {
        Log("WARN", line);
    }
}