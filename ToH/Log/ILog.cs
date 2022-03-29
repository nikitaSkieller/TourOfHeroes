namespace ToH.Log;

public interface ILog
{
    void Debug(string line);
    void Info(string line);
    void Warn(string line);
    void Error(string line);
}