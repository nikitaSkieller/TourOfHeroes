using ToH.Data;
using ToH.Log;

namespace ToH.Screens;

public class Ui : IObserver
{
    private readonly Controller _controller;
    private readonly ILog _log;
    public Screen Screen { get; set; }

    public Ui(Controller controller, Screen screen, ILog log)
    {
        _controller = controller;
        _log = log;
        Screen = screen;
        _controller.Add(this);
    }

    public void Update()
    {
        switch (_controller.Action)
        {
            case Action.None:
                Screen.None(this);
                break;
            case Action.Down:
                Screen.Down(this);
                break;
            case Action.Up:
                Screen.Up(this);
                break;

            default:
                _log.Log($"Unhandled action: {_controller.Action}");
                break;
        }

    }

    public void Print()
    {
        Screen.None(this);
    }
}