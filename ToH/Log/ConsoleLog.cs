namespace ToH.Log;

public class ConsoleLog : ILog
{
    public void Log(string line)
    {
        Console.WriteLine($"{new DateTime()} - {line}");
    }
}