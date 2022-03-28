namespace ToH.BLL;
// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class Controller : AbstractSubject
// [CR_Claudio] Shouldn't this class be in the presentation layer, given that it interacts with the "outside world"?
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