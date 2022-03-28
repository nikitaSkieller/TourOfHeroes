using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace ToH.BLL;
// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class Controller : AbstractSubject
{
    public virtual Action Action { get; private set; }
    public virtual string? value { get; private set; }
    public void ListenForInput()
    {
        bool notExit = true;
        while (notExit)
        {
            var line = Console.ReadLine();

            switch (line)
            {
                case "w":
                    Action = Action.Up;
                    break;
                case "s":
                    Action = Action.Down;
                    break;
                case "d":
                    Action = Action.Enter;
                    break;
                case "a":
                    Action = Action.Escape;
                    break;
                case "q":
                    notExit = false;
                    break;
                default:
                    value = line;
                    Action = Action.Text;
                    break;
            }
            Notify();
        }
    }
}