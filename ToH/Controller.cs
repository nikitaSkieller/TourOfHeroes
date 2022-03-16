using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace ToH;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class Controller : AbstractSubject
{
    public virtual Action Action { get; private set; }
    public void ListenForInput()
    {
        bool notExit = true;
        while (notExit)
        {
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    Action = Action.Up;
                    break;
                case ConsoleKey.DownArrow:
                    Action = Action.Down;
                    break;
                case ConsoleKey.Enter:
                    Action = Action.Enter;
                    break;
                case ConsoleKey.Backspace:
                    Action = Action.Escape;
                    break;
                case ConsoleKey.Q:
                    notExit = false;
                    break;
                default:
                    Console.WriteLine($"Unknown key {key.Key}");
                    break;
            }
            Notify();
        }
    }
}