namespace ToH.PL;

public interface IPrinter
{
    void Clear();
    void PrintLine(string line);
    void Print(string text);
}

public class ConsolePrinter : IPrinter
{
    public void Clear()
    {
        Console.Clear();
    }

    public void PrintLine(string line)
    {
        Console.WriteLine(line);
    }

    public void Print(string text)
    {
        Console.Write(text);
    }
}