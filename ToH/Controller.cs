using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ToH;

public enum Action
{
    None,
    Up,
    Down,
    Enter,
}

public class Controller : AbstractSubject
{
    public Action Action { get; private set; }
    public void ListenForInput()
    {
        bool notExit = true;
        while (notExit)
        {
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    Action = Action.Up;
                    Notify();
                    break;
                case ConsoleKey.DownArrow:
                    Action = Action.Down;
                    Notify();
                    break;
                case ConsoleKey.Q:
                    notExit = false;
                    break;
                default:
                    Console.WriteLine($"{key.Key}");
                    break;
            }
        }
    }
}