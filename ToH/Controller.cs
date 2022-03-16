using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
                    Notify();
                    break;
                case ConsoleKey.DownArrow:
                    Action = Action.Down;
                    Notify();
                    break;
                case ConsoleKey.Enter:
                    Action = Action.Enter;
                    Notify();
                    break;
                case ConsoleKey.Q:
                    notExit = false;
                    break;
                default:
                    Console.WriteLine($"Unknown key {key.Key}");
                    break;
            }
        }
    }
}